     public ActionResult Login(Auth aut)
        {
            if (ModelState.IsValid)
            {
               string result = objrepo.validateUser(aut);
                ViewBag.Success = result;
            }
            return View();
        }
