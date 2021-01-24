    [RoutePrefix("api")]
    public class PresidentsController : ApiController
    {
        [Route("presidents")]
        public async Task<IHttpActionResult> GetPresidents()
        {
            await Task.Delay(TimeSpan.FromSeconds(10));
            return Ok();
        }
    }
    
