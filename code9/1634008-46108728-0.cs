    ApplicationUser x = System.Web.HttpContext.Current.GetOwinContext()
       .GetUserManager<ApplicationUserManager>()
       .FindById(System.Web.HttpContext.Current.User.Identity.GetUserId());
    
    ViewBag.Gender = x.Gender;
