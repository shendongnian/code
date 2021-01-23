        public class AccountController : Controller
        {
            [Authorize]
            [HttpGet]
            public async Task<IActionResult> MethodName()
            {
                var rolesClaim = HttpContext.User.Claims.Where( c => c.Type == ClaimsIdentity.DefaultRoleClaimType).FirstOrDefault();
                //...
                return Ok();
            }
        }
