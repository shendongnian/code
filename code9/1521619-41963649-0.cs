    [RoutePrefix("api/mine")]
    public class mineController : ApiController
    {
    	[Route("method1")]
    	[HttpGet]
    	public IHttpActionResult Method1()
    	{
    		//Route would be api/mine/method1
    	}
    	
    	[Route("method2")]
    	[HttpGet]
    	public IHttpActionResult Method2()
    	{
    		//Route would be api/mine/method2
    	}
    }
