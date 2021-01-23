        [HttpPost]
        public ActionResult LoggedIn()
        {
            Session["UserLogin"] = true;
            return RedirectToAction("Index", "Home");
        }
