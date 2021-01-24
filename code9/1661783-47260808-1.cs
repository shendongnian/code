    public class Functions
    {
	    private readonly ISystemClient _systemClient;
	    public Functions(ISystemClient systemClient)
	    {
	    	_systemClient = systemClient;
	    }
	    //Not static anymore
	    [NoAutomaticTrigger]
	    public void ManualTrigger(TextWriter log, int value, [Queue("queue")] out string message)
	    {
		    log.WriteLine("Function is invoked with value={0}", value);
		    message = value.ToString();		    
		    log.WriteLine("username:{0} and password:{1}", _systemClient.UserName, _systemClient.PassWord);
	    }
    }
