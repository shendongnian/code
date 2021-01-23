    public class CheckOwnerActionFilter : ActionFilterAttribute, IActionFilter
     {    
       AppDbContext db = new AppDbContext();
       void IActionFilter.OnActionExecuting(ActionExecutingContext  filterContext)
        {
         int userId = AppUserManager.GetUserId();
         var userEntity = db.UserProfiles.FirstOrDefault(t => t.UserId == userId);
         if (userEntity != null)
         {
          //Its means authorized
         }
         else
         {
           HttpContext.Current.Response.Redirect("~/unauthorize/index");
         }
       }
     }
    
