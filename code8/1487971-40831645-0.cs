    public ActionResult Login(string returnUrl)
        {
           if (User.Identity.IsAuthenticated)
            {
                //already logged in - no need to allow login again!!
                return RedirectToAction("Index", "Home");
            }
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public ActionResult Login(UserProfile register)
        {
            //check your model state!
            if(!ModelState.IsValid) return View();
            //this method returns some result letting you know if the user 
            //logged in successfully or not.  You need to check that. 
            
            //Additionally, this method sets the Auth cookie so you can 
            //do you IsAuthenticated call anywhere else in the system 
            var loginResult = WebSecurity.Login(register.UserName, register.password, true);
            //login failed, display the login view again or go whereever you need to go
            if(!loginResult) return View();
             //Good to go, user is authenticated - redirect to where need to go
            return RedirectToAction("Index", "Home");
        }
