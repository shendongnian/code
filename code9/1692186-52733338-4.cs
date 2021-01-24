    public class AccountController : Controller
    {
        [AllowAnonymous]
        [Route("/login")]
        public async Task<IActionResult> Login()
        {
            if (User == null || !User.Identities.Any(identity => identity.IsAuthenticated))
            {
                // By default the client will be redirect back to the URL that issued the challenge (/login?authtype=foo),
                // send them to the home page instead (/).
                string returnUrl = HttpContext.Request.Query["ReturnUrl"];
                returnUrl = string.IsNullOrEmpty(returnUrl) ? "/" : returnUrl;
                await HttpContext.ChallengeAsync("Google", new AuthenticationProperties() { RedirectUri = returnUrl });
            }
            return View();
        }
        [Authorize]
        [Route("/logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme, new AuthenticationProperties() { RedirectUri="/" });
            return View();
        }
    }
