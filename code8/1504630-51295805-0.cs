    using SendGrid;
    using SendGrid.Helpers.Mail;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    
    namespace Somenamespace.Utils
    {
    	public class SMTPUtils
    	{
    
    		public async void SendEmail(string address, string toName, string fromName, string fromAddress, string subject, string body)
    		{
    			SendGridMessage msg = new SendGridMessage();
    			msg.SetFrom(new EmailAddress(fromAddress, fromName));
    			var recipients = new List<EmailAddress>
    			{
    				new EmailAddress(address, toName),
    			};
    			msg.AddTos(recipients);
    			msg.SetSubject(subject);
    			msg.AddContent(MimeType.Text, body);
    
    			await Execute(msg);
    		}
    
    		private async Task Execute(SendGridMessage msg)
    		{
    			var client = new SendGridClient(yourAPIKey);
    			var response = await client.SendEmailAsync(msg);
    		}
    	}
    }
    
    protected void BtnSubmit_Click(object sender, EventArgs e)
    {
    	string body = "some message body";
    
    	SMTPUtils smtp = new SMTPUtils();
    	smtp.SendEmail("someone@somewhere.com", "Bill Jo Bob Tex Jr.", "fromsomeone@somewhere.com", "noreply@example.com", "subject", body);
    }
