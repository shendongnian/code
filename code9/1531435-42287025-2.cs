    public class LoginController : Controller
    {
    	private readonly ITest _test;
    
    	public LoginController(ITest test)
    	{
            _test = test;
    		var aaa = _test.TestMethod();
    		
    		// Do other stuff...
    	}
    }
