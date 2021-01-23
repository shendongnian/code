    public class WebAPIDemoController : ApiController {
        [ActionName("GetUser")]
        [HttpGet]
        [Route("api/WebAPIDemo/GetUserById")]
        public IHttpActionResult GetUserById(int id) {
            var context = new UsersContext();
            var user = context.GetUserById(id);
            return Ok(user);
        }
    }
