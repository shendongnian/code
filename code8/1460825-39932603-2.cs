    [Route("api/[controller]")]
    public class AuthController : Controller {
        private readonly IAuthenticationService auth;
    
        public AuthController(IAuthenticationService auth) {
            this.auth = auth;
        }
    
        // POST api/login
        [HttpPost]
        [Route("login")]
        public LoginResponseModel Login([FromBody] LoginModel user) {
            return auth.Login(user);
        }
    }
