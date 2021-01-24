	public class TestController : ApiController
	{
		[RoutePrefix("api/Whatever")]
		public TestController(IClass1 class1)
		{
			// At this point, your class1 will have been
			// instantiated by Unity.
		}
		
		[HttpGet]
		[Route("EvenMore")]
		public HttpResponseMessage EvenMore(string foo)
		{
		}
	}
