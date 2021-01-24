    public class HomeController : Controller
    {
        [HttpPost]
        public IActionResult MyActionMethod()
        {
            Response.Cookies.Append(
            OpenIdConnectAuthenticationDefaults.CookieNoncePrefix + Options.StringDataFormat.Protect(nonce),
            NonceProperty,
            new CookieOptions
            {
                HttpOnly = true,
                Secure = Request.IsHttps,
                Expires = DateTime.UtcNow + Options.ProtocolValidator.NonceLifetime
            });
    
            return View();
        }
    }
