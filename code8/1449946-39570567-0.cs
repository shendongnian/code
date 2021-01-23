    public class CheckOwnerActionFilter : ActionFilterAttribute, IActionFilter
     {    
       AppDbContext db = new AppDbContext();
       void IActionFilter.OnActionExecuting(ActionExecutingContext  filterContext)
        {
         int userId = AppUserManager.GetUserId();
        var userEntity = db.UserProfiles.FirstOrDefault(t => t.UserId == userId);
        if (userEntity != null)
         {
          var returnEntity = db.FATCA_OECDFATCAReturns.FirstOrDefault(t => t.Id == returnID);
          if (returnEntity != null)
           {
            if (userEntity.FIId == returnEntity.FIId)
             {
             }
             else
            {
              HttpContext.Current.Response.Redirect("~/unauthorize/index");
            }
         }
       }
     }
    }
