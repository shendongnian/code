    public ActionResult Index(LoginViewModel vm , string submitBtn)
    { 
       if(submitBtn == "Login")
       {
         //do the login thing &  
           return View("Index", vm);
       }
       if(submitBtn == "Reset")
       { 
         // do the reset password thing and
         return View("Index", vm);
       }
    }
