    public ActionResult LogOff()
        {
            HttpContext.Session.Remove(SessionKeys.UserType);//This will remove all keys from session variable. For example, if your session contains id, name, phone number, email etc.
            HttpContext.Session.RemoveAll();//This will remove all session from application
            FormsAuthentication.SignOut();            
            return RedirectToAction("Login", "Account");
        }
