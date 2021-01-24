    [RoutePrefix("api/SystemHealt")]
    public class SystemHealtController : ApiController
    {
        [HttpGet]
        public IHttpActionResult UpdateUsageDetail(string cpuUsage, string 
         memoryUsage, string diskUsage)
        {
              // Do Stuff
            return Ok();
        }
