    [RoutePrefix("healthcheck")]
    public class HealthCheckController : ApiController {
        [HttpGet]
        [Route("")] // Matches GET http://mysite/healthcheck
        public IHttpActionResult GetHealthCheckStatus() {
            return Ok();
        }
    }
