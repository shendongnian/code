        public ActionResult Login(LoginModel login)
        {
           if(ModelState.IsValid)
           {
              //you call your service to get back the result
               
              if(!NotAValidUser)
              { 
                 ModelState.AddModelError("LoginFailed", "The user name and or password is incorrect.")
              }
           }
        }
