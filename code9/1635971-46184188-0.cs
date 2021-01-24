        public async Task<IActionResult> OnGetAsync()
        {
            var request = HttpContext.Request;
            var sessionId = request.Query.FirstOrDefault().Value;
            var session = await _httpService.ValidateSession(sessionId);
            if (!string.IsNullOrEmpty(sessionId))
            {
                var claims = new List<Claim>()
                {
                    new Claim(CustomClaimTypes.UserId, session.UserId),
                    new Claim(CustomClaimTypes.BuId, session.BuId),
                    new Claim(CustomClaimTypes.SecurityLevel, session.SecurityLevel)
                };
                var identity = new ClaimsIdentity(claims, "TNReadyEVP");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal,
                    new AuthenticationProperties { ExpiresUtc = DateTime.Now.AddMinutes(60), IsPersistent = true, AllowRefresh = false });
                var isAuthenticated = principal.Identity.IsAuthenticated;
                return File("index.html", "text/html");
            }
            else
            {
                return RedirectToPage("Error");
            }
        }
