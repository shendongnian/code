    [Authorize]
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController {
        //...code removed for brevity
    
        [HttpPost]//<-- this guy
        [AllowAnonymous]
        [Route("Register")] //Matches POST api/Account/Register
        public async Task<IHttpActionResult> Register(RegisterBindingModel model) {
            //...code removed for brevity
        }
    }
