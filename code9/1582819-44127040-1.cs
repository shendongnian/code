    public class CanEditReport : ActionFilterAttribute  
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var reportID = Convert.ToInt32(filterContext.ActionParameters["id"]);
            var report = ReportsManager.GetByID(reportID);
            int userID = 0;
            bool hasID = int.TryParse(filterContext.HttpContext.Session["CurrentUserID"].ToString(), out userID);
            if (!hasID)
            {
                filterContext.Controller.TempData["FlashMessage"] = "Please select a valid User to access their reports.";
                //Change the Result to point back to Home/Index
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
            }
            else //We have selected a valid user
            {
                if(report.UserID != userID)
                {
                    filterContext.Controller.TempData["FlashMessage"] = "You cannot view Reports you have not created.";
                    //Change the Result to point back to Home/Index
                    filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new { controller = "Home", action = "Index" }));
                }
            }
            base.OnActionExecuting(filterContext);
        }
    }
