       [HttpGet]
        public async Task<ActionResult> Index() {
            ADServices ads = new ADServices();
            var userPrin = ads.GetUser(User.Identity.Name);
            ViewBag.UserName = userPrin.GivenName + " " + userPrin.Surname;
            ...(other code omitted)
            return View(model);
        }
