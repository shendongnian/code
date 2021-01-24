           get
           {
               return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
           }
           private set
           {
               _userManager = value;
               _user = null;
           }
       }
       ApplicationUser _user;
       private ApplicationUser User
       {
           get
           {
               if (_user == null)
               {
                   _user = System.Web.HttpContext.Current.GetOwinContext()
                       .GetUserManager<ApplicationUserManager>()                               
                       .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
               }
               return _user;
           }
       }
