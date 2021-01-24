    [RoutePrefix("api/v1/Register")]
    public class RegisterController : ApiController {
        [HttpGet]
        [Route("{id:int}",Name = "GetUser")] //Matches GET api/v1/Register/1
        public async Task<IHttpActionResult> Get(int id) {
            //...code removed for brevity
        }
    }
