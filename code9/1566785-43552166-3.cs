    [HttpGet]
        public ActionResult ForgotPassword()
        {
            Models.FirstMV model = new Models.FirstMV();
            return View(model);
        }
        [HttpPost]
        public ActionResult ForgotPassword(Models.FirstMV model)
        {
            // Do forgot password stuff and redirect
            Models.SecondMV secondModel = new Models.SecondMV
            {
                Email = model.Email,
                
            };
            return RedirectToAction("ForgotPasswordCode", "Home", secondModel);
        }
        [HttpGet]
        public ActionResult ForgotPasswordCode(Models.FirstMV model)
        {
            Models.SecondMV secondModel = new Models.SecondMV
            {
                Email = model.Email
            };
            return View(secondModel);
        }
        [HttpPost]
        public ActionResult ForgotPasswordCode(Models.SecondMV model)
        {
            if (model.Token == "MyTokenValue")
            {
                return RedirectToAction("ForgotPasswordSuccess", "Home");
            }
            else
            {
                return RedirectToAction("ForgotPasswordFailed", "Home");
            }
        }
        [HttpGet]
        public ActionResult ForgotPasswordSuccess()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ForgotPasswordFailed()
        {
            return View();
        }
