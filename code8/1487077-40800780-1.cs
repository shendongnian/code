    public class DataController : ApiController
    {
    	[HttpPost]  
    	[ActionName("post1")]      
    	public HttpResponseMessage Post([StringBody]string data)
    	{
    	   // Logic
    	}
    
    	[HttpPost]
    	[ActionName("post2")]
    	public HttpResponseMessage Post(Requirements objRequirement)
    	{ 
    	  //Logic
    	}
    }
