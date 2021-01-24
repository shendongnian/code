    // The RoleSettings is a class of constants I defined that just contain strings
    [AccessDeniedAuthorize(Roles = RoleSettings.AdminRole]
    [HttpPost]
    public ActionResult MyEditMethod()
    {
       // Perform actions if they are in the AdminRole
       // If not authorized, it will do whatever you defined above in the 
       // AccessDeniedAuthorizeAttribute
    }
