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
                Token = Guid.NewGuid().ToString()
            };
            return RedirectToAction("ForgotPasswordCode", "Home", secondModel);
        }
        public ActionResult ForgotPasswordCode(Models.SecondMV model)
        {
            return View(model);
        }
