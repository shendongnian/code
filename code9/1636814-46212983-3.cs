    public class HealthCheckController : ApiController
    {
        [AcceptVerbs("GET")]
        [Route("healthcheck")]
        public HttpResponseMessage GetHealthCheckStatus()
        {
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
