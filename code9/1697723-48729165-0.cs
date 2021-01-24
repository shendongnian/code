     [AllowAnonymous]
            public ActionResult Register()
            {
                return View();
            }
    
            //
            // POST: /Account/Register
            [HttpPost]
            [AllowAnonymous]
            [ValidateAntiForgeryToken]
            public async Task<ActionResult> Register(RegisterViewModel model)
            {
                if (ModelState.IsValid)
                {
                // a lot goes in here
                }
                return View(model);
            }
