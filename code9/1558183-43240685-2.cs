    [Route("api/[controller]")]
        public class sampleController : ApiController
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
