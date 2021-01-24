    public class LoginController : Controller
    {
    	public ITest Test { get; set; }
    
    	public LoginController()
    	{
            // Test is null, will always be null here
    		var aaa = Test.TestMethod();
    	}
    }
