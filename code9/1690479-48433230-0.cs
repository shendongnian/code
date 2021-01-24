    public class Global : System.Web.HttpApplication
    {
    	public Global()
    	{
    	}
    
    	protected void Application_Start() 
        {
    		Trace.TraceInformation("In application start");
        } 
    }
