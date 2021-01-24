    public ActionResult Login()
        {
            if (SessionManager.UserId == -1)
            {
                HttpCookie cookie = Request.Cookies["Login"];// Request.Cookies["Login"];
                if (cookie != null)
                {
                    ViewBag.hdnUserID = cookie.Values[0];
                    ViewBag.hdnPassword = cookie.Values[1];
                    ViewBag.hdnRemember = "true";
                }
                return View("Login");
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
