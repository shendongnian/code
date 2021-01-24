    public class EmailSenderFactory : IEmailSenderFactory
    {
    	public IEmailSender CreateSender(EmailTarget emailTarget)
    	{
    		switch (emailTarget)
    		{
    			case EmailTarget.Gmail:
    				return new GmailEmailSender();
    
    			case EmailTarget.Yahoo:
    				return new YahooEmailSender();
    
    			default:
    				throw new InvalidOperationException($"Unknown email target {emailTarget}");
    		}
    	}
    }
