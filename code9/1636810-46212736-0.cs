	[RoutePrefix("healthcheck")]
	public class HealthCheckController : ApiController
	{
		[HttpGet]
		[Route]
		public IHttpActionResult GetHealthCheckStatus()
		{
			return Ok();
		}
	}
