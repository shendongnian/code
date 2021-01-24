        public ActionResult Authenticate(Users u)
        {
            if (basicOps.getUsersLogin(u.UserName, u.Password)) 
            {
                return RedirectToAction("GetImagesStories", "Stories");
            }
            return View("Authenticate");
        }
