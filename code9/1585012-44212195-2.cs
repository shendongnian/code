    public class LoginController : ApiController {
    
        [HttpGet]
        [Route("~/api/v1/login/{username}/{password}")]
        [ResponseType(typeof(LoginResult))]
        public LoginResult GetLoginInfo(string username, string password) {
            //v1 logic
        }
    
        [HttpGet]
        [Route("~/api/v2/login/{username}/{password}")]
        [ResponseType(typeof(LoginResult))]
        public LoginResult GetLoginInfo2(string username, string password) {
            //v2 logic
        }
    } 
