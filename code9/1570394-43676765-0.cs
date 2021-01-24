    public class Configs
    {
      //your base config stuff here
    }   
    
    public class HomeController : Controller //note only inherits framework controller
    {
    	
    	private Configs _configs;
    
    	public HomeController()
    	{
    		_configs = new Configs()
    	}
    
    	public ActionResult Home()
    	{
    		//use _configs here
    	}
    }
