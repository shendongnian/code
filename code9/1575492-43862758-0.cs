            [HttpGet]
            [Route("login")]
            public ActionResult Login(string returnUrl)
            {
                if (Request.IsAuthenticated)
                    return RedirectToAction("Home", "Dashboard");
    
                return View(new AccountLoginModel() { ReturnUrl = returnUrl });
            }
    
            [HttpGet]
            public ActionResult Login()
            {
                
                if (Request.IsAuthenticated)
                    return RedirectToAction("Home", "Dashboard");
    
                return View(new AccountLoginModel() { ReturnUrl = string.Empty });
            }
