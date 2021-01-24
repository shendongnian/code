    public class LoginController : Controller
    {
    	private ITest _test;
    	public ITest Test 
        { 
          get { return _test; }
          set 
          {
            var initialize = (_test == null);
            _test = value;
            if (initialize)
            {
              Initialize();
            }
          }
        }
    
    	public LoginController()
    	{
    	}
        private void Initialize()
        {
          var aaa = Test.TestMethod();
        }
    }
