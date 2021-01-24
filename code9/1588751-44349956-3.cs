    [RoutePrefix("api/user")]
    public class UserController : ApiController {
        private readonly IBucket _bucket = ClusterHelper.GetBucket(ConfigurationManager.AppSettings.Get("CouchbaseUserBucket"));
        private readonly string _secretKey = ConfigurationManager.AppSettings["JWTTokenSecret"];
        [HttpPost]
        [Route("signup")] //Matches POST api/user/signup
        public async Task<IHttpActionResult> SignUp(LoginModel model) {
            //...code removed for brevity
        }
    }
