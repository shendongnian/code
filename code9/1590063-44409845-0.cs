    protected override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (User.Identity.IsAuthenticated && Session["LayoutViewModel"] == null)
            {
                var lvm = new LayoutViewModel { AppUserId = User.Identity.GetUserId() };
                lvm.LoggedInUserProfile =
                    MyProject.Services.UserService.UserHelpers.GetProfileForLoggedInUser(lvm.AppUserId);
                if (lvm.LoggedInUserProfile != null)
                {
                    Session["LayoutViewModel"] = lvm;
                }
                else
                {
                    Session["LayoutViewModel"] = null;
                }
               
            }
            base.OnActionExecuted(filterContext);
        }
