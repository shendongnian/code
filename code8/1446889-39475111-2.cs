      public ActionResult LogOut()
                {
                    Request.GetOwinContext().Authentication.SignOut("ApplicationCookie");
        
                    return RedirectToAction("Login");
                }
