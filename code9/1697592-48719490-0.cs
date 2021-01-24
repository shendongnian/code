    public class UpdateLastAccessFilter : ActionFilterAttribute, IActionFilter
    {
    	void IActionFilter.OnActionExecuting(ActionExecutingContext filterContext)
    	{
    		// TODO: Add your action filter's tasks here
    
    		// Log Action Filter call
    		using (dbEntities context = new dbEntities())
    		{
    			
    			var id = context.User.Claims.First(x => x.Type == "sub").Value;
    
            var user = db.AspNetUsers.Find(id);
    
            user.LastAccessed = DateTime.Now;
    
            await db.SaveChangesAsync();
    			OnActionExecuting(filterContext);
    		}
    	}
    }
