	public class InitController : ApiController
	{
		[Route("/app/init")]
		public IHttpActionResult Index()
		{
			//do your initialisation / warmup here
			return Ok();
		}
	}
