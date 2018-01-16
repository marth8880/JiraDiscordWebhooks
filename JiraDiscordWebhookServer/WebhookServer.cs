using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NHttp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JiraDiscordWebhookForms
{
	public partial class WebhookServer : Form
	{
		// TODO: Change these to match your configuration
		private static string localIP = "http://SERVER_LOCAL_IP/";
		private static string jiraIconURL = "https://JIRA_ICON_URL";
		private static string jiraBaseURL = "http://JIRA_BASE_URL/browse/";
		private static string discordURL = "https://DISCORD_WEBHOOK_URL";
		private static string botName = "JIRA";

		public WebhookServer()
		{
			InitializeComponent();
			
			//StartServer();
		}

		Thread serverThread;
		private void WebhookServer_Load(object sender, EventArgs e)
		{
			serverThread = new Thread(StartListening);
			serverThread.Start();
		}
		
		private void btn_Start_Click(object sender, EventArgs e)
		{
			//StartServer();
		}

		private void btn_Stop_Click(object sender, EventArgs e)
		{
			//StopServer();
		}

		
		private static readonly HttpClient client = new HttpClient();

		private ServerStatus status = ServerStatus.Idle;

		private ServerStatus SetServerStatus(ServerStatus value)
		{
			status = value;
			lbl_StatusValue.Text = status.ToString();
			return status;
		}

		bool stopListening = false;
		HttpListener listener;
		public void StartListening()
		{
			Debug.WriteLine("In StartListening");

			while (true)
			{
				listener = new HttpListener();
				listener.Prefixes.Add(localIP);
				listener.Start();

				Trace.WriteLine("Listening...");

				if (stopListening)
				{
					Debug.WriteLine("Time to stop listening.");
					listener.Stop();
					break;
				}

				HttpListenerContext context = listener.GetContext();
				HttpListenerRequest request = context.Request;

				if (stopListening)
				{
					Debug.WriteLine("Time to stop listening.");
					listener.Stop();
					break;
				}

				HttpListenerResponse response = context.Response;
				if (request.InputStream != null)
				{
					using (var reader = new StreamReader(request.InputStream, Encoding.UTF8))
					{
						var content = reader.ReadToEnd();
						dynamic json = JObject.Parse(content);
						var ev = "";
						try
						{
							ev = json.issue_event_type_name.Value;
							ev = ev.Replace("_", " ");
							ev = ev.First().ToString().ToUpper() + ev.Substring(1);
							Trace.WriteLine("Issue event type name: " + ev);

							if (ev == "Issue generic")
							{
								ev = "Issue moved to '" + json.issue.fields.status.name.Value + "'";
							}
						}
						catch (Exception ex)
						{
							var msg = ex.Message;
							Trace.WriteLine(msg);

							ev = json.webhookEvent.Value;
							Trace.WriteLine("Webhook event: " + ev);
							return;
						}
						var authorName = "";
						dynamic author = null;
						try
						{
							author = json.user;
							authorName = json.user.displayName.Value;
							//botName = authorName + " (JIRA)";
						}
						catch (Exception ex)
						{
							var msg = ex.Message;
							Trace.WriteLine(msg);

							author = json.comment.author;
							authorName = json.comment.author.displayName.Value;
							//botName = authorName + " (JIRA)";
						}
						var link = "";
						var issueKey = "";
						var issueSummary = "";
						var issueDescription = "";
						var commentContents = "";
						var commentId = "";
						try
						{
							commentContents = json.comment.body.Value;
							commentId = json.comment.id.Value;

							issueKey = json.issue.key.Value;
							link = jiraBaseURL + issueKey + "?focusedCommentId=" + commentId;
							issueSummary = json.issue.fields.summary.Value;
							issueDescription = json.issue.fields.description.Value;
						}
						catch (Exception ex)
						{
							var msg = ex.Message;
							Trace.WriteLine(msg);

							issueKey = json.issue.key.Value;
							link = jiraBaseURL + issueKey;
							issueSummary = json.issue.fields.summary.Value;
							issueDescription = json.issue.fields.description.Value;
						}
						if (issueDescription != "")
						{
							// Convert code tags
							issueDescription = issueDescription.Replace("{{", "```\n");
							issueDescription = issueDescription.Replace("}}", "\n```");
							issueDescription = issueDescription.Replace("{code}\r\n", "```\n");
							issueDescription = issueDescription.Replace("\r\n{code}", "\n```");

							// Remove bold formatting
							issueDescription = issueDescription.Replace("*", "");

							// Trim length
							if (issueDescription.Length > 250)
							{
								issueDescription = issueDescription.Substring(0, 250);

								// Is there an odd number of code tags?
								int numTags = Regex.Matches(issueDescription, "```").Count;
								if (numTags % 2 != 0)
								{
									// Close the last tag
									issueDescription += " ...\n```" + "\n([see full description](" + link + "))";
								}
								else
								{
									issueDescription += " ... ([see full description](" + link + "))";
								}
							}
						}
						var avatarUrl = ((author.avatarUrls as IEnumerable<object>).First() as dynamic).Value.Value;

						Trace.WriteLine("Got webhook event '" + ev + "' [" + issueSummary + "]" + " by " + authorName);

						var discordMessage = new DiscordHookMessage(botName, issueKey, issueSummary, issueDescription, ev, link, authorName, avatarUrl, commentContents, commentId);
						var discordMessageJSON = JsonConvert.SerializeObject(discordMessage, Formatting.Indented);
						var resp = client.PostAsync(discordURL, new StringContent(discordMessageJSON, Encoding.UTF8, "application/json")).Result;
						Trace.WriteLine("Discord response code: " + resp.StatusCode);
					}
				}
				using (var writer = new StreamWriter(response.OutputStream))
				{
					writer.Write("Hello world!");
					writer.Close();
				}

				listener.Stop();
			}
		}


		public void StopListening()
		{
			Debug.WriteLine("Time to stop listening.");
			listener.Stop();
			serverThread.Abort();
		}



		public enum ServerStatus
		{
			Running,
			Idle
		}
		

		// DATA STRUCTURES 
		
		class DiscordAttachmentField
		{
			public string name { get; set; }
			public string value { get; set; }
		}

		class DiscordAuthorField
		{
			public string name { get; set; }
			public string icon_url { get; set; }
		}

		class DiscordAttachment
		{
			public DiscordAuthorField author { get; set; }
			public string title { get; set; }
			public string url { get; set; }
			public string description { get; set; }
			public IList<DiscordAttachmentField> fields { get; set; }
		}

		class DiscordHookMessage
		{
			public string username { get; set; }
			public string avatar_url { get; set; }
			public string content { get; set; }
			public IList<DiscordAttachment> embeds { get; set; }

			public DiscordHookMessage(string discordBotName, string issueKey, string issueSummary, string issueDescription, string eventType, string link, string authorName, string avatarUrl, string commentContents, string commentId)
			{
				username = discordBotName;
				avatar_url = jiraIconURL;
				List<DiscordAttachmentField> embedFields = null;

				if (!eventType.Contains("comment"))
				{
					embedFields = new List<DiscordAttachmentField>()
					{
						new DiscordAttachmentField()
						{
							name = "Summary",
							value = issueSummary
						},

						new DiscordAttachmentField()
						{
							name = "Description",
							value = issueDescription
						}
					};
				}
				else
				{
					if (commentContents == "" || commentId == "")
					{
						return;
					}

					embedFields = new List<DiscordAttachmentField>()
					{
						new DiscordAttachmentField()
						{
							name = "Summary",
							value = issueSummary
						},

						new DiscordAttachmentField()
						{
							name = "Comment",
							value = commentContents
						}
					};
				}

				if (embedFields == null)
				{
					return;
				}

				embeds = new List<DiscordAttachment>()
				{
					new DiscordAttachment()
					{
						author = new DiscordAuthorField()
						{
							name = authorName,
							icon_url = avatarUrl
						},

						title = eventType + " – (" + issueKey + ") " + issueSummary,
						url = link,
						//description = eventType,

						fields = embedFields
					}
				};
			}
		}

		private void WebhookServer_FormClosing(object sender, FormClosingEventArgs e)
		{
			Debug.WriteLine("WebhookServer_FormClosing");
			StopListening();
		}
	}

	public static class StringExtension
	{
		public static string GetLast(this string source, int tailLength)
		{
			if (tailLength >= source.Length)
				return source;
			return source.Substring(source.Length - tailLength);
		}
	}
}
