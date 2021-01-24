        [HttpPost()]
        [Route("api/[Controller]/[Action]/")]
        public async Task<JsonResult> Login([FromBody]Dictionary<string, string> loginData)
        {
            try
            {
                var loggedIn = true;
                var user = new APP_USER();
                if (loggedIn)
                {
                    var claims = new List<Claim> {
                        new Claim(ClaimTypes.Name, "tanush")
                    };
                    
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaims(claims);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(
                        "tanushCookie",
                        principal,
                        new AuthenticationProperties
                        {
                            IsPersistent = true,
                            ExpiresUtc = DateTime.UtcNow.AddDays(7)
                        });
                }
                return new JsonResult(logRtn);
            }
            catch (Exception ex)
            {
                return new JsonResult(ex.Message);
            }
        }
