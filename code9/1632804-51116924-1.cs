    [RoutePrefix("api/v2/value")]
    public class ValueV2Controller : ApiController
    {
    	[Route("get")]
    	public IEnumerable<string> Get()
    	{
    		return new string[] { "value1.2", "value2.2" };
    	}
    }
