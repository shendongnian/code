    public class EmailSender
    {
    	private readonly IEmailSenderFactory senderFactory;
    
    	public EmailSender(IEmailSenderFactory senderFactory)
    	{
    		this.senderFactory = senderFactory;
    	}
    
    	public void Send(EmailTarget emailTarget)
    	{
    		var sender = senderFactory.CreateSender(emailTarget);
    		sender.SendEmail();
    	}
    }
