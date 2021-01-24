    [RoutePrefix("api/v1/value")]
    public class ValueV1Controller : ApiController
    {
    	[Route("get")]
    	public IEnumerable<string> Get()
    	{
    		return new string[] { "value1", "value2" };
    	}
    }
