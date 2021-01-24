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
    			SmtpClient SmtpServer = new SmtpClient("sampleSmtp.sampleTest.com");
    			mail.From = new MailAddress("your_email_address@gmail.com");
    			mail.To.Add(email.ToAddress);
    			mail.Subject = email.Subject;
    			mail.Body = email.Body;
    			smtpClient.Send(mail);
    		}
    	}
    }
