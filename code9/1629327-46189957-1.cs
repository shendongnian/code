        [HttpPost()]
        [Route("api/[Controller]/[Action]/")]
        public async Task<JsonResult> Login([FromBody]Dictionary<string, string> loginData)
        {
            try
            {
                var loggedIn = true;
                if (loggedIn)
                {
                    var claims = new List<Claim> {
                        new Claim(ClaimTypes.Name, "John Doe")
                    };
                    
                    var identity = new ClaimsIdentity(CookieAuthenticationDefaults.AuthenticationScheme);
                    identity.AddClaims(claims);
                    ClaimsPrincipal principal = new ClaimsPrincipal(identity);
                    await HttpContext.SignInAsync(
                        "ACE_AUTH",
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
