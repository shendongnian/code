            [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] //Based on Scheme it will auth, for cookie mention [Authorize(AuthenticationSchemes = CookieAuthenticationDefaults.AuthenticationScheme)]
            public IActionResult About()
            {
                ViewData["Message"] = "Your application description page.";
                return View();
            }
