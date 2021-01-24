    namespace DemoOdataFunction.Controllers
    {
        public class AnotherModelsController : ApiController
        {
            public IHttpActionResult Get(int parameterC)
            {
                // ...
                return Ok();
            }
    
            public IHttpActionResult Get()
            {
                // ...
                return Ok("Ok");
            }
    
            [HttpPost]
            public IHttpActionResult Post(AnotherModel model)
            {
                // ...
                return Ok();
            }
        }
    }
    
	
