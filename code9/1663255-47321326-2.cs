    public interface ISmtpClient
    {
    	int Port { get; set; }
    
    	ICredentialsByHost Credentials { get; set; }
    
    	bool EnableSsl { get; set; }
    
    	void Send(MailMessage mail);
    }
    
    public class SmtpClientWrapper : SmtpClient, ISmtpClient
    {
    }
    
    public class BatchProcess
    {
    	private readonly ISmtpClient smtpClient;
    
    	BatchProcess(ISmtpClient smtpClient)
    	{
    		this.smtpClient = smtpClient;
    	}
    
    	public void SendMail(List<EmailEntity> emails)
    	{
    		foreach (EmailEntity email in emails)
    		{
    			MailMessage mail = new MailMessage();
    			mail.From = new MailAddress("your_email_address@gmail.com");
    			mail.To.Add(email.ToAddress);
    			mail.Subject = email.Subject;
    			mail.Body = email.Body;
    
    			//	You could leave this configuration here but it's far better to have it configured in SmtpClientWrapper constructor
    			//  or at least outside the loop
    			smtpClient.Port = 587;
    			smtpClient.Credentials = new System.Net.NetworkCredential("username", "password");
    			smtpClient.EnableSsl = true;
    
    			smtpClient.Send(mail);
    		}
    	}
    }
