    [RoutePrefix("api/JobDetail")] 
    public class JobDetailController : ApiController {
    
        [HttpGet]
        [Route("")] //Matches GET api/jobdetail
        public IEnumerable<JobDetail> Get() {
            //...
        }
    
        [HttpGet]
        [Route("{id:int}")] //Matches GET api/jobdetail/1
        public HttpResponseMessage Get(int id) {
           //...
        }
    
        [HttpGet]
        [Route("{locationName}")] //Matches GET api/jobdetail/somewhere
        public HttpResponseMessage RetrieveJobByLocation(string locationName) {
            //...
        }
    
        [HttpDelete]
        [Route("{jobId:int}")] //Matches DELETE api/jobdetail/1
        public HttpResponseMessage Delete(int jobId) {
            //...
        }
    }
