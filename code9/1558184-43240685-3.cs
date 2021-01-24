    [RoutePrefix("api/Data")]
        public class DataController : ApiController
        {
          [Route("LoadReport")]
            [HttpGet]
            public HttpResponseMessage LoadReport()
                {
                    ...
                }
            
            [Route("LoadReport2")]
            [HttpGet]
            public HttpResponseMessage LoadReport2()
                {
                    ...
                }
