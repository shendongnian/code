    [Route("api/[controller]/[action]")]
    public class AccountController : Controller
    {
        [AllowAnonymous]
        [HttpPost]
        public void Login()
        {
             //some logic
              HttpContext.Response.WriteAsync("Unauthorized");
        }
    }
