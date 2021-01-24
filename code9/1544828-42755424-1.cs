    public class BaseController : Controller
    {
    	private string _username;
    
    	protected string Username
    	{
    		get
    		{
    			if (_username == null)
    			{
    				_username = User.Identity.Name;
                }
    	        return _username;
    		}
    	}
    }
