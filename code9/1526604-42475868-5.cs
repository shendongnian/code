    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(String username, String password, String returnUrl = null)
    {
        ViewData["ReturnUrl"] = returnUrl;
        if (ModelState.IsValid)
        {
            // check user's password hash in database
            // retrieve user info
    
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, username),
                new Claim("FirstName", "Alice"),
                new Claim("LastName", "Smith")
            };
    
            var identity = new ClaimsIdentity(claims, "Password");
    
            var principal = new ClaimsPrincipal(identity);
    
            await HttpContext.Authentication.SignInAsync("MyCookieMiddlewareInstance", principal);
    
            return RedirectToLocal(returnUrl);
        }
    
        ModelState.AddModelError(String.Empty, "Invalid login attempt.");
    
        return View();
    }
