    public class Application
    {
    	private Token _token = null;
    	
    	public void logInMethod()
        {
            LogIn logInObject = new LogIn();
            _token = logInObject.logUserIn("user", "password");
        }
    }
    
    public class Token
    {
    	public string UserName { get; }
    	private string Password { get; }
    	private bool Validated { get; }
    }
    
    public class LogIn
    {
    	public Token logUserIn(string userName, string password)
    	{
    		/* ... */
    	}
    
    }
