        public class AccountController : Controller
        {
            [Authorize]
            [HttpGet]
            public async Task<IActionResult> MethodName()
            {
                var userId = _userManager.GetUserId(HttpContext.User);
                //...
                return Ok();
            }
        }
