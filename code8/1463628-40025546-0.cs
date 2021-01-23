    protected override void OnActionExecuting(ActionExecutingContext filterContext)
    {
        if (showChagePwPage)
        {
            //redirect to the change password page
            filterContext.Result = new RedirectToActionResult("ChangePassword", "Account");
        }
        
        base.OnActionExecuting(filterContext);
    }
