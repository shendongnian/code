    namespace WebAPIa.Controllers
    {
       // [Route("api/[controller]")]
        public class DataController : ApiController
        {
            [ActionName("LoadReport")]
            [HttpGet]
            public HttpResponseMessage LoadReport()
            {
    
               return Request.CreateResponse("Testing LoadReport");
            }
    
            [ActionName("LoadReport2")]
            [HttpGet]
            public HttpResponseMessage LoadReport2()
            {
                return Request.CreateResponse("Testing LoadReport2");
            }
        }
    }
