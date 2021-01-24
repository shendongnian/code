        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {                
                // modify below to match your user table structure to pull user info
                userTable vUser = _yourDB_Context.userTable.SingleOrDefault(m => m.Email == model.Email && m.password == model.Password);
                const string Issuer = "optional: company name / issuer name";
                List<Claim> claims = new List<Claim> {
                    new Claim("CompanyName", "YourCompany"), // hardcoded to authorize EmployeeOnly
                    //new Claim("department", "HR"),
                    //new Claim(ClaimTypes.Name, vUser.Name, ClaimValueTypes.String, Issuer),
                    new Claim(ClaimTypes.Email, vUser.Email, ClaimValueTypes.String, Issuer),
                    //new Claim(ClaimTypes.Role, vUser.Roles, ClaimValueTypes.String, Issuer)
                };
                var userIdentity = new ClaimsIdentity(claims, "local", "name", "role");
                var userPrincipal = new ClaimsPrincipal(userIdentity);
                await HttpContext.Authentication.SignInAsync("yourcookiename", userPrincipal,
                    new AuthenticationProperties {
                        ExpiresUtc = DateTime.UtcNow.AddMinutes(30),
                        IsPersistent = false,
                        AllowRefresh = false
                    });
                return RedirectToLocal(returnUrl);                
            }
            return View(model);
        }
