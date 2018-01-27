using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
		public bool formVisible = true;
		Prefs prefs = new Prefs();

		public WebhookServer()
		{
			InitializeComponent();

			//StartServer();
		}

		Thread serverThread;
		private void WebhookServer_Load(object sender, EventArgs e)
		{
			// Auto-hide the form upon boot
			ToggleFormVisibility(false);

			// Get our user preferences
			prefs = LoadPrefs();

			// Auto-fill the text fields with the user prefs
			txt_LocalIP.Text = prefs.LocalIP;
			txt_JiraIconURL.Text = prefs.JiraIconURL;
			txt_JiraBaseURL.Text = prefs.JiraBaseURL;
			txt_DiscordURL.Text = prefs.DiscordURL;
			txt_BotName.Text = prefs.BotName;
			txt_BugIconURL.Text = prefs.BugIconURL;
			txt_TaskIconURL.Text = prefs.TaskIconURL;
			txt_EpicIconURL.Text = prefs.EpicIconURL;

			Application.ThreadException += new ThreadExceptionEventHandler(Application_ThreadException);

			try
			{
				serverThread = new Thread(StartListening);
				serverThread.Start();
			}
			catch (Exception)
			{
				Debug.WriteLine("catch Exception");
				MessageBox.Show("Crashed");
			}
		}

		static void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
		{
			Debug.WriteLine("Application_ThreadException");
			MessageBox.Show("Application_ThreadException");
		}

		private void WebhookServer_FormClosing(object sender, FormClosingEventArgs e)
		{
			Debug.WriteLine("WebhookServer_FormClosing");
			StopListening();
		}

		private void btn_Start_Click(object sender, EventArgs e)
		{
			StartListening_Flow();
		}

		private void btn_Stop_Click(object sender, EventArgs e)
		{
			StopListening_Flow();
		}

		private void btn_SaveSettings_Click(object sender, EventArgs e)
		{
			prefs.LocalIP = txt_LocalIP.Text;
			prefs.JiraIconURL = txt_JiraIconURL.Text;
			prefs.JiraBaseURL = txt_JiraBaseURL.Text;
			prefs.DiscordURL = txt_DiscordURL.Text;
			prefs.BotName = txt_BotName.Text;
			prefs.BugIconURL = txt_BugIconURL.Text;
			prefs.TaskIconURL = txt_TaskIconURL.Text;
			prefs.EpicIconURL = txt_EpicIconURL.Text;

			SavePrefs(prefs);
		}

		private void ToggleFormVisibility(bool visible)
		{
			Debug.WriteLine("ToggleFormVisibility - " + visible);
			if (visible)
			{
				formVisible = true;
				this.Show();
				WindowState = FormWindowState.Normal;
			}
			else
			{
				formVisible = false;
				this.Hide();
				WindowState = FormWindowState.Minimized;
			}
		}

		private void WebhookServer_Resize(object sender, EventArgs e)
		{
			if (FormWindowState.Minimized == this.WindowState)
			{
				Debug.WriteLine("WebhookServer_Resize: WindowState - Minimized");
				ToggleFormVisibility(false);
			}
			else if (FormWindowState.Normal == this.WindowState)
			{
				Debug.WriteLine("WebhookServer_Resize: WindowState - Normal");
				ToggleFormVisibility(true);
			}
		}

		private void notifyIcon_DoubleClick(object sender, EventArgs e)
		{
			if (FormWindowState.Minimized == this.WindowState)
			{
				Debug.WriteLine("notifyIcon_Click: WindowState - Minimized");
				ToggleFormVisibility(true);
			}
			else if (FormWindowState.Normal == this.WindowState)
			{
				Debug.WriteLine("notifyIcon_Click: WindowState - Normal");
				ToggleFormVisibility(false);
			}
		}

		private void toggleVisibilityToolStripMenuItem_Click(object sender, EventArgs e)
		{
			ToggleFormVisibility(!formVisible);
		}

		private void startToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StartListening_Flow();
		}

		private void stopToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StopListening_Flow();
		}

		private void quitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			StopListening_Flow();
			this.Close();
		}

		private void StartListening_Flow()
		{
			Thread.Sleep(200);
			if (GetServerStatus() == ServerStatus.Running) { return; }
			serverThread = new Thread(StartListening);
			serverThread.Start();
		}

		private void StopListening_Flow()
		{
			StopListening();
		}


		public void SavePrefs(Prefs savedPrefs)
		{
			Properties.Settings.Default.LocalIP = savedPrefs.LocalIP;
			Properties.Settings.Default.JiraIconURL = savedPrefs.JiraIconURL;
			Properties.Settings.Default.JiraBaseURL = savedPrefs.JiraBaseURL;
			Properties.Settings.Default.DiscordURL = savedPrefs.DiscordURL;
			Properties.Settings.Default.BotName = savedPrefs.BotName;
			Properties.Settings.Default.BugIconURL = savedPrefs.BugIconURL;
			Properties.Settings.Default.TaskIconURL = savedPrefs.TaskIconURL;
			Properties.Settings.Default.EpicIconURL = savedPrefs.EpicIconURL;

			Properties.Settings.Default.Save();
		}


		public Prefs LoadPrefs()
		{
			Debug.WriteLine("Loading prefs...");

			Prefs newPrefs = new Prefs
			{
				LocalIP = Properties.Settings.Default.LocalIP,
				JiraIconURL = Properties.Settings.Default.JiraIconURL,
				JiraBaseURL = Properties.Settings.Default.JiraBaseURL,
				DiscordURL = Properties.Settings.Default.DiscordURL,
				BotName = Properties.Settings.Default.BotName,
				BugIconURL = Properties.Settings.Default.BugIconURL,
				TaskIconURL = Properties.Settings.Default.TaskIconURL,
				EpicIconURL = Properties.Settings.Default.EpicIconURL
			};

			Debug.WriteLine("LocalIP:     " + newPrefs.LocalIP);
			Debug.WriteLine("JiraIconURL: " + newPrefs.JiraIconURL);
			Debug.WriteLine("JiraBaseURL: " + newPrefs.JiraBaseURL);
			Debug.WriteLine("DiscordURL:  " + newPrefs.DiscordURL);
			Debug.WriteLine("BotName:     " + newPrefs.BotName);
			Debug.WriteLine("BugIconURL:  " + newPrefs.BugIconURL);
			Debug.WriteLine("TaskIconURL: " + newPrefs.TaskIconURL);
			Debug.WriteLine("EpicIconURL: " + newPrefs.EpicIconURL);

			return newPrefs;
		}


		private static readonly HttpClient client = new HttpClient();

		private ServerStatus status = ServerStatus.Idle;

		private void SetServerStatus(ServerStatus value)
		{
			SetServerStatus_Proc(value);
		}

		delegate void SetServerStatusCallback(ServerStatus value);

		private void SetServerStatus_Proc(ServerStatus value)
		{
			if (lbl_StatusValue.InvokeRequired)
			{
				SetServerStatusCallback cb = new SetServerStatusCallback(SetServerStatus_Proc);
				BeginInvoke(cb, new object[] { value });
			}
			else
			{
				status = value;
				lbl_StatusValue.Text = status.ToString();
				notifyIcon.Text = "JIRA Webhook Server: " + status.ToString();
			}
		}


		private ServerStatus GetServerStatus()
		{
			return status;
		}


		bool stopListening = false;
		HttpListener listener;

		public void StartListening()
		{
			if (GetServerStatus() == ServerStatus.Running) { return; }
			Debug.WriteLine("In StartListening");

			SetServerStatus(ServerStatus.Running);

			while (true)
			{
				try
				{
					listener = new HttpListener();
					listener.Prefixes.Add(prefs.LocalIP);
					listener.Start();
				}
				catch (Exception e)
				{
					var msg = e.Message;
					Trace.WriteLine(msg);
				}

				Trace.WriteLine("Listening...");

				if (stopListening)
				{
					Debug.WriteLine("Time to stop listening.");
					listener.Stop();
					break;
				}

				HttpListenerContext context;
				HttpListenerRequest request;

				try
				{
					context = listener.GetContext();
					request = context.Request;
				}
				catch (HttpListenerException e)
				{
					var msg = e.Message + "\n\n";
					msg += "Either run this application as administrator, which you'll have to do every time it's started, or enter the following command (all in one line and without quotes) in an elevated command prompt, which you'll only have to do once: \n\n";
					msg += "'netsh http add urlacl url=http://LOCAL_IP:PORT/ user=COMPUTER_NAME\\WIN_ACCOUNT_NAME'\n\n";
					msg += "Change LOCAL_IP and PORT to the local IP and port to listen on, and COMPUTER_NAME and WIN_ACCOUNT_NAME to the computer name and Windows account username.";
					Trace.WriteLine(msg);
					MessageBox.Show(msg);
					return;
				}
				catch (InvalidOperationException e)
				{
					var msg = e.Message;
					Trace.WriteLine(msg);
					MessageBox.Show(msg);
					return;
				}

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
						var eventType = "";
						try
						{
							eventType = json.issue_event_type_name.Value;
							eventType = eventType.Replace("_", " ");
							eventType = eventType.First().ToString().ToUpper() + eventType.Substring(1);
							Trace.WriteLine("Issue event type name: " + eventType);

							if (eventType == "Issue generic")
							{
								eventType = "Issue moved to '" + json.issue.fields.status.name.Value + "'";
							}
						}
						catch (Exception ex)
						{
							var msg = ex.Message;
							Trace.WriteLine(msg);

							eventType = json.webhookEvent.Value;
							Trace.WriteLine("Webhook event: " + eventType);
							return;
						}

						JiraUser user = new JiraUser();
						dynamic author = null;
						try
						{
							author = json.user;
							user.Name = json.user.displayName.Value;
							//prefs.BotName = user.Name + " (JIRA)";
						}
						catch (Exception ex)
						{
							var msg = ex.Message;
							Trace.WriteLine(msg);

							author = json.comment.author;
							user.Name = json.comment.author.displayName.Value;
							//prefs.BotName = user.Name + " (JIRA)";
						}

						JiraIssue issue = new JiraIssue();
						JiraComment comment = new JiraComment();
						try
						{
							comment.Contents = json.comment.body.Value;
							comment.Id = json.comment.id.Value;

							issue.Key = json.issue.key.Value;
							issue.Url = prefs.JiraBaseURL + issue.Key + "?focusedCommentId=" + comment.Id;
							issue.Type = json.issue.fields.issuetype.name.Value;
							issue.Summary = json.issue.fields.summary.Value;
							issue.Description = json.issue.fields.description.Value;
							issue.Status = json.issue.fields.status.name.Value;
							issue.Resolution = json.issue.fields.resolution.Value;
							if (issue.Resolution == null) { issue.Resolution = "Unresolved"; }
							issue.Reporter = new JiraUser
							{
								Name = json.issue.fields.reporter.displayName.Value,
								AvatarUrl = ((json.issue.fields.reporter.avatarUrls as IEnumerable<object>).First() as dynamic).Value.Value
							};
							if (json.issue.fields.assignee == null)
							{
								issue.Assignee = new JiraUser { Name = "*Unassigned*" };
							}
							else
							{
								issue.Assignee = new JiraUser
								{
									Name = json.issue.fields.assignee.displayName.Value,
									AvatarUrl = ((json.issue.fields.assignee.avatarUrls as IEnumerable<object>).First() as dynamic).Value.Value
								};
							}
							issue.UpdatedTimestamp = json.issue.fields.updated.Value;
						}
						catch (Exception ex)
						{
							var msg = ex.Message;
							Trace.WriteLine(msg);

							issue.Key = json.issue.key.Value;
							issue.Url = prefs.JiraBaseURL + issue.Key;
							issue.Type = json.issue.fields.issuetype.name.Value;
							issue.Summary = json.issue.fields.summary.Value;
							issue.Description = json.issue.fields.description.Value;
							issue.Status = json.issue.fields.status.name.Value;
							issue.Resolution = json.issue.fields.resolution.Value;
							if (issue.Resolution == null) { issue.Resolution = "Unresolved"; }
							issue.Reporter = new JiraUser
							{
								Name = json.issue.fields.reporter.displayName.Value,
								AvatarUrl = ((json.issue.fields.reporter.avatarUrls as IEnumerable<object>).First() as dynamic).Value.Value
							};
							if (json.issue.fields.assignee == null)
							{
								issue.Assignee = new JiraUser { Name = "*Unassigned*"};
							}
							else
							{
								issue.Assignee = new JiraUser
								{
									Name = json.issue.fields.assignee.displayName.Value,
									AvatarUrl = ((json.issue.fields.assignee.avatarUrls as IEnumerable<object>).First() as dynamic).Value.Value
								};
							}
							issue.UpdatedTimestamp = json.issue.fields.updated.Value;
						}
						if (issue.Description != null && issue.Description != "")
						{
							// Convert code tags
							issue.Description = issue.Description.Replace("{{", "```\n");
							issue.Description = issue.Description.Replace("}}", "\n```");
							issue.Description = issue.Description.Replace("{code}\r\n", "```\n");
							issue.Description = issue.Description.Replace("\r\n{code}", "\n```");

							// Remove bold formatting
							issue.Description = issue.Description.Replace("*", "");

							// Trim length
							if (issue.Description.Length > 250)
							{
								issue.Description = issue.Description.Substring(0, 250);

								// Is there an odd number of code tags?
								int numTags = Regex.Matches(issue.Description, "```").Count;
								if (numTags % 2 != 0)
								{
									// Close the last tag
									issue.Description += " ...\n```" + "\n([see full description](" + issue.Url + "))";
								}
								else
								{
									issue.Description += " ... ([see full description](" + issue.Url + "))";
								}
							}
						}
						else
						{
							issue.Description = "*No description*";
						}

						try
						{
							user.AvatarUrl = ((author.avatarUrls as IEnumerable<object>).First() as dynamic).Value.Value;
						}
						catch (Exception ex)
						{
							var msg = ex.Message;
							Trace.WriteLine(msg);
						}

						DiscordBot bot = new DiscordBot
						{
							Name = prefs.BotName,
							AvatarUrl = prefs.JiraIconURL
						};

						JiraIssueIcons issueIcons = new JiraIssueIcons
						{
							BugIconURL = prefs.BugIconURL,
							TaskIconURL = prefs.TaskIconURL,
							EpicIconURL = prefs.EpicIconURL
						};

						Trace.WriteLine("Got webhook event '" + eventType + "' [" + issue.Summary + "]" + " by " + user.Name);

						try
						{
							var discordMessage = new DiscordHookMessage(bot, eventType, user, issue, issueIcons, comment);
							var discordMessageJSON = JsonConvert.SerializeObject(discordMessage, Formatting.Indented);
							var resp = client.PostAsync(prefs.DiscordURL, new StringContent(discordMessageJSON, Encoding.UTF8, "application/json")).Result;
							Trace.WriteLine("Discord response code: " + resp.StatusCode);
						}
						catch (Exception ex)
						{
							var msg = ex.Message;
							Trace.WriteLine(msg);
							//MessageBox.Show(msg);
						}
					}
				}
				try
				{
					using (var writer = new StreamWriter(response.OutputStream))
					{
						writer.Write("Hello world!");
						writer.Close();
					}

					listener.Stop();
				}
				catch (IOException ex)
				{
					var msg = ex.Message;
					Trace.WriteLine(msg);
				}
				catch (ObjectDisposedException ex)
				{
					var msg = ex.Message;
					Trace.WriteLine(msg);
				}
			}
		}


		public void StopListening()
		{
			if (GetServerStatus() == ServerStatus.Idle) { return; }
			Debug.WriteLine("Time to stop listening.");

			try
			{
				SetServerStatus(ServerStatus.Idle);
				Thread.Sleep(200);
				listener.Stop();
				serverThread.Abort();
			}
			catch (ObjectDisposedException ex)
			{
				var msg = ex.Message;
				Trace.WriteLine(msg);
			}
			catch (ThreadStateException ex)
			{
				var msg = ex.Message;
				Trace.WriteLine(msg);
			}
		}



		public enum ServerStatus
		{
			Running,
			Idle
		}
		

		public class Prefs
		{
			public string LocalIP { get; set; }
			public string JiraIconURL { get; set; }
			public string JiraBaseURL { get; set; }
			public string DiscordURL { get; set; }
			public string BotName { get; set; }
			public string BugIconURL { get; set; }
			public string TaskIconURL { get; set; }
			public string EpicIconURL { get; set; }

			public Prefs()
			{
				LocalIP = Properties.Settings.Default.LocalIP;
				JiraIconURL = Properties.Settings.Default.JiraIconURL;
				JiraBaseURL = Properties.Settings.Default.JiraBaseURL;
				DiscordURL = Properties.Settings.Default.DiscordURL;
				BotName = Properties.Settings.Default.BotName;
				BugIconURL = Properties.Settings.Default.BugIconURL;
				TaskIconURL = Properties.Settings.Default.TaskIconURL;
				EpicIconURL = Properties.Settings.Default.EpicIconURL;
			}
		}


		// DATA STRUCTURES

		class JiraUser
		{
			public string Name { get; set; }
			public string AvatarUrl { get; set; }
		}

		class JiraComment
		{
			public string Id { get; set; }
			public string Contents { get; set; }
		}

		class JiraPriorityField
		{
			public string Name { get; set; }
			public string IconUrl { get; set; }
		}

		class JiraIssue
		{
			public string Url { get; set; }
			public string Key { get; set; }
			public string Type { get; set; }
			public string Summary { get; set; }
			public string Description { get; set; }
			public string Status { get; set; }
			public string Resolution { get; set; }
			public string Priority { get; set; }
			public JiraUser Reporter { get; set; }
			public JiraUser Assignee { get; set; }
			public DateTime UpdatedTimestamp { get; set; }
		}

		class JiraIssueIcons
		{
			public string BugIconURL { get; set; }
			public string TaskIconURL { get; set; }
			public string EpicIconURL { get; set; }
		}

		class DiscordBot
		{
			public string Name { get; set; }
			public string AvatarUrl { get; set; }
		}
		
		class DiscordAttachmentField
		{
			public string name { get; set; }
			public string value { get; set; }
			public bool inline { get; set; }
		}

		class DiscordAuthorField
		{
			public string name { get; set; }
			public string icon_url { get; set; }
		}

		class DiscordFooterField
		{
			public string text { get; set; }
			public string icon_url { get; set; }
		}

		class DiscordAttachment
		{
			public DiscordAuthorField author { get; set; }
			public int color { get; set; }
			public string title { get; set; }
			public string url { get; set; }
			public string description { get; set; }
			public IList<DiscordAttachmentField> fields { get; set; }
			public DiscordFooterField footer { get; set; }
			public DateTime timestamp { get; set; }
		}

		class DiscordHookMessage
		{
			public string username { get; set; }
			public string avatar_url { get; set; }
			public string content { get; set; }
			public IList<DiscordAttachment> embeds { get; set; }

			
			public DiscordHookMessage(DiscordBot bot, string eventType, JiraUser user, JiraIssue issue, JiraIssueIcons issueIcons, JiraComment comment)
			{
				username = bot.Name;
				avatar_url = bot.AvatarUrl;
				List<DiscordAttachmentField> embedFields = null;

				if (!eventType.Contains("comment"))
				{
					embedFields = new List<DiscordAttachmentField>()
					{
						new DiscordAttachmentField()
						{
							name = "Summary",
							value = issue.Summary
						},

						new DiscordAttachmentField()
						{
							name = "Description",
							value = issue.Description
						},

						new DiscordAttachmentField()
						{
							name = "Assignee",
							value = issue.Assignee.Name,
							inline = true
						},

						new DiscordAttachmentField()
						{
							name = "Status",
							value = issue.Status,
							inline = true
						},

						new DiscordAttachmentField()
						{
							name = "Resolution",
							value = issue.Resolution,
							inline = true
						}
					};
				}
				else
				{
					if (comment.Contents == "" || comment.Id == "")
					{
						return;
					}

					embedFields = new List<DiscordAttachmentField>()
					{
						new DiscordAttachmentField()
						{
							name = "Summary",
							value = issue.Summary
						},

						new DiscordAttachmentField()
						{
							name = "Comment",
							value = comment.Contents
						},

						new DiscordAttachmentField()
						{
							name = "Assignee",
							value = issue.Assignee.Name,
							inline = true
						},

						new DiscordAttachmentField()
						{
							name = "Status",
							value = issue.Status,
							inline = true
						},

						new DiscordAttachmentField()
						{
							name = "Resolution",
							value = issue.Resolution,
							inline = true
						}
					};
				}

				if (embedFields == null)
				{
					return;
				}

				// Set the color decimal value for the issue type - values taken from Jira's default icons
				int embedColor;
				string footerText = eventType.Replace("Issue", issue.Type);
				string footerIconUrl = "";
				switch (issue.Type)
				{
					case "Bug":
						embedColor = 15026490;  // rgb: 229, 73, 58
						footerIconUrl = issueIcons.BugIconURL;
						break;
					case "Task":
						embedColor = 4959720;   // rgb: 75, 173, 232
						footerIconUrl = issueIcons.TaskIconURL;
						break;
					case "Epic":
						embedColor = 9457378;   // rgb: 144, 78, 226
						footerIconUrl = issueIcons.EpicIconURL;
						break;
					default:
						embedColor = 8421504;	// rgb: 128, 128, 128
						break;
				}

				DiscordFooterField embedFooter = new DiscordFooterField()
				{
					text = footerText,
					icon_url = footerIconUrl
				};

				embeds = new List<DiscordAttachment>()
				{
					new DiscordAttachment()
					{
						author = new DiscordAuthorField()
						{
							name = user.Name,
							icon_url = user.AvatarUrl
						},

						color = embedColor,
						title = eventType + " – (" + issue.Key + ") " + issue.Summary,
						url = issue.Url,
						//description = eventType,

						fields = embedFields,

						footer = embedFooter,
						timestamp = issue.UpdatedTimestamp
					}
				};
			}
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
