    	using System;
		using System.Data;
		using System.Timers;
		using System.Net.Mail;
		using System.Windows.Forms;
		using System.Speech.Synthesis;
		using System.Collections.Generic;
		namespace Alerts
		{
			public partial class frmAlerts : Form
			{
				SpeechSynthesizer speechSynthesizerObj;
				Common ComMsg = new Common();
				DataSet DatMsg = new DataSet();
				DataSet DatNames = new DataSet();
				AlertException error = new AlertException();
				List<string> AlertList = new List<string>();
				string ToName;
				string ToEmail;
				string TotMsg;
				string _Name;
				public frmAlerts()
				{
					InitializeComponent();
					this.WindowState = FormWindowState.Minimized;
				}
				private void frmAlerts_Load(object sender, EventArgs e)
				{
					try
					{
						System.Timers.Timer timer = new System.Timers.Timer(20 * 60 * 1000);
						timer.Elapsed += new ElapsedEventHandler(SendAlerts);
						timer.Start();
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error in application Load: " + ex.Message);
						SendtoAdmin();
					}
				}
				public void SendAlerts(object source, ElapsedEventArgs e)
				{
					try
					{
						DatNames = ComMsg.ReturnDataSet("SELECT Name FROM RptAlertRecipient ORDER BY Name DESC");
						for (int i = 0; i < DatNames.Tables[0].Rows.Count; i++)
						{
							_Name = DatNames.Tables[0].Rows[i].ItemArray.GetValue(0).ToString();
							DatMsg = ComMsg.ReturnDataSet("SELECT RptAlertRecipient.Name,  RptAlertRecipient.Email,  RptAlerts.Factory,  RptAlerts.AlertTime,  RptAlerts.Description " +
											   "FROM RptAlerts " +
											   "INNER JOIN RptAlertTypes ON  RptAlerts.AlertTypeID = RptAlertTypes.ID " +
											   "INNER JOIN RptAlertType_RecipientMapping ON  RptAlertTypes.ID = RptAlertType_RecipientMapping.AlertTypeID " +
											   "INNER JOIN RptAlertRecipient ON  RptAlertType_RecipientMapping.AlertRecipientID = RptAlertRecipient.ID " +
											   "WHERE RptAlertRecipient.Name ='" + _Name + "'" +
											   "ORDER BY RptAlertRecipient.Name DESC");
							for (int j = 0; j < DatMsg.Tables[0].Rows.Count; j++)
							{
								ToEmail = DatMsg.Tables[0].Rows[j].ItemArray.GetValue(1).ToString();
								ToName = DatMsg.Tables[0].Rows[j].ItemArray.GetValue(0).ToString();
								AlertList.Add(DatMsg.Tables[0].Rows[j].ItemArray.GetValue(4).ToString() + "<br/>");
								TotMsg = (j + 1).ToString();
							}
							string to = ToEmail;
							string from = "helpdesk@mydomain.com";
							string subject = "Alert In Time : You Have " + TotMsg + " Alerts";
							string msgBody = "Dear " + ToName + ",<br/><br/>";
							msgBody += "<b>You Have " + TotMsg + " Alerts</b><br/><br/>";
							msgBody += string.Join("<br/>", AlertList);
							msgBody += "<br/><br/>Regards<br/>Sent by Alert Service<br/>(Please do not reply to this email.)";
							MailMessage msg = new MailMessage(from, to, subject, msgBody);
							msg.IsBodyHtml = true;
							SmtpClient clnt = new SmtpClient("outlook.mydomain.local", 25);
							clnt.EnableSsl = false;
							clnt.Credentials = new System.Net.NetworkCredential("helpdesk@mydomain.com", "password");
							clnt.Send(msg);
							AlertList.Clear();
						}
					}
					catch (Exception ex)
					{
						error.ExceptionMessage = ex.ToString();
						speechSynthesizerObj = new SpeechSynthesizer();
						speechSynthesizerObj.SpeakAsync(ex.Message);//Speaks the Error
						SendtoAdmin();
					}
				}
				#region SendMails
				protected void SendtoAdmin()
				{
					//Send mail to Admin
					string to = "admin@mydomain.com";
					string from = "helpdesk@mydomain.com";
					string subject = "System Failure";
					string msgBody = "Dear Admin,<br/><br/>System Failure in Alert System.<br/>Please Attend Immediately.<br/>"+ error.ExceptionMessage + "<br/><br/>Regards<br/>Sent By Alert System";
					MailMessage msg = new MailMessage(from, to, subject, msgBody);
					msg.IsBodyHtml = true;
					SmtpClient clnt = new SmtpClient("outlook.mydomain.local", 25);
					clnt.EnableSsl = false;
					clnt.Credentials = new System.Net.NetworkCredential("helpdesk@mydomain.com", "sl@ithd");
					clnt.Send(msg);
				}
				#endregion		
			}
		}
