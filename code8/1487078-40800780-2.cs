    [RoutePrefix("api/data")]
    public class DataController : ApiController
    {
    	[HttpPost]  
    	[Route("post1")]      
    	public HttpResponseMessage Post([StringBody]string data)
    	{
    	   // Logic
    	}
    
    	[HttpPost]
    	[Route("post2")]
    	public HttpResponseMessage Post(Requirements objRequirement)
    	{ 
    	  //Logic
    	}
    }
