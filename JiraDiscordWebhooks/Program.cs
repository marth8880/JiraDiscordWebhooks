using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using NHttp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace JiraDiscordWebhooks
{
	class Program
	{
		class DiscordAttachmentField
		{
			public string title { get; set; }
			public string value { get; set; }
		}

		class DiscordAttachment
		{
			public string author_icon { get; set; }
			public string author_name { get; set; }
			public IList<DiscordAttachmentField> fields { get; set; }
		}

		class DiscordHookMessage
		{
			//public string username { get; set; }
			public string icon_url { get; set; }
			public string text { get; set; }
			public IList<DiscordAttachment> attachments { get; set; }

			public DiscordHookMessage(string issueTitle, string eventType, string link, string authorName, string avatarUrl)
			{
				icon_url = jiraIconURL;
				text = "";
				attachments = new List<DiscordAttachment>()
			{
				new DiscordAttachment()
				{
					author_icon = avatarUrl,
					author_name = authorName,
					fields = new List<DiscordAttachmentField>()
					{
						new DiscordAttachmentField()
						{
							title = eventType + " [" + issueTitle + "]",
							value = link
						}
					}
				}
			};
			}
		}

		// SET THESE HOW YOU WANT
		private static string localIP = "SERVER_LOCAL_IP";
		private static int port = 8095;
		private static string jiraIconURL = "http://JIRA_BASE_URL/images/64jira.png";
		private static string jiraBaseURL = "http://JIRA_BASE_URL/browse/";
		private static string discordURL = "https://DISCORD_WEBHOOK_URL";

		private static readonly HttpClient client = new HttpClient();

		static void Main(string[] args)
		{
			using (var server = new HttpServer())
			{
				server.EndPoint = new IPEndPoint(IPAddress.Parse(localIP), port);
				server.RequestReceived += (s, e) =>
				{
					if (e.Request.InputStream != null)
					{
						using (var reader = new StreamReader(e.Request.InputStream, Encoding.UTF8))
						{
							var content = reader.ReadToEnd();
							dynamic json = JObject.Parse(content);
							var ev = "";
							try
							{
								ev = json.issue_event_type_name.Value;
								ev = ev.Replace("_", " ");
								ev = ev.First().ToString().ToUpper() + ev.Substring(1);
								//Console.WriteLine("Issue event type name: " + ev);

								if (ev == "Issue generic")
								{
									ev = "Issue moved to '" + json.issue.fields.status.name.Value + "'";
								}
							}
							catch (Exception)
							{
								return;
								//ev = json.webhookEvent.Value;
								//Console.WriteLine("Webhook event: " + ev);
							}
							var authorName = "";
							dynamic author = null;
							try
							{
								author = json.user;
								authorName = json.user.emailAddress.Value;
							}
							catch (Exception)
							{
								author = json.comment.author;
								authorName = json.comment.author.emailAddress.Value;
							}
							var link = "";
							var issueKey = "";
							var issueTitle = "";
							try
							{
								issueKey = json.issue.key.Value;
								link = jiraBaseURL + issueKey;
								issueTitle = issueKey + " - " + json.issue.fields.summary.Value;
							}
							catch (Exception) { }
							var avatarUrl = ((author.avatarUrls as IEnumerable<object>).First() as dynamic).Value.Value;

							Console.WriteLine("Got webhook event '" + ev + "' [" + issueTitle + "]" + " by " + authorName);

							var discordMessage = new DiscordHookMessage(issueTitle, ev, link, authorName, avatarUrl);
							var discordMessageJSON = JsonConvert.SerializeObject(discordMessage, Formatting.Indented);
							var resp = client.PostAsync(discordURL, new StringContent(discordMessageJSON, Encoding.UTF8, "application/json")).Result;
							Console.WriteLine("Discord response code: " + resp.StatusCode);
						}
					}
					using (var writer = new StreamWriter(e.Response.OutputStream))
					{
						writer.Write("Hello world!");
					}
				};

				server.Start();

				Console.WriteLine("Server started. Press any key to exit.");
				Console.ReadKey();
			}
		}
	}
}