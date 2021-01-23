    public class HomeController : Controller
    {
    	private readonly IDistributedCache _distributedCache;
     
    	public HomeController(IDistributedCache distributedCache)
    	{
    		_distributedCache = distributedCache;
    	}
     
    	[HttpGet]
    	public async Task<string> Get()
    	{
    		//You can access _distributedCache here. 
    	}
    }
