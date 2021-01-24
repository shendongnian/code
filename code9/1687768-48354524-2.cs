    public class EmailSenderFactory : IEmailSenderFactory
    {
    	private readonly IUnityContainer diContainer;
    
    	public EmailSenderFactory(IUnityContainer diContainer)
    	{
    		this.diContainer = diContainer;
    	}
    
    	public IEmailSender CreateSender(EmailTarget emailTarget)
    	{
    		switch (emailTarget)
    		{
    			case EmailTarget.Gmail:
    				return diContainer.Resolve<GmailEmailSender>();
    
    			case EmailTarget.Yahoo:
    				return diContainer.Resolve<YahooEmailSender>();
    
    			default:
    				throw new InvalidOperationException($"Unknown email target {emailTarget}");
    		}
    	}
    }
