    [RoutePrefix("api/v1/Register")]
    public class RegisterController : ApiController {
        [HttpGet]
        [Route("GetUser/{id:int}",Name = "GetUser")] //Matches GET api/v1/Register/GetUser/1
        public async Task<IHttpActionResult> Get(int id) {
            //...code removed for brevity
        }
    }
