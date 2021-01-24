    ///Create an action :
            
             public ActionResult Unauthorized()
                    {
                        return View();
                    }    
    //// now write below code for authorization        
       
    
      protected override void HandleUnauthorizedRequest(System.Web.Mvc.AuthorizationContext filterContext)
                    {
            
                        if (filterContext.HttpContext.Request.IsAuthenticated)
                        {
                            //redirect to the Unauthenticated page
                            filterContext.Result = new RedirectToRouteResult(new 
     RouteValueDictionary(new { controller = "Error", action = "Unauthorized" 
     }));
                        }
                        else
                        {
                            base.HandleUnauthorizedRequest(filterContext);
                        }
                    }
            
            
            
                    protected override bool AuthorizeCore(HttpContextBase httpContext)
                    {
                        var authorized = base.AuthorizeCore(httpContext);
            
            
                        if (!authorized)
                        {
                            // The user is not authenticated
                            return false;
                        }
                       else{
           var getList = 
             _objService.GetUserRoleDetail(CommonStaticHelper.getLoggedUser());
        
                foreach (var role in allowedroles)
                {
                    if (getList.Exists(m => m.RoleId == role))
                    {
                        return authorize = true; /* return true if Entity has current 
                       user(active) with specific role */
                    }
                }
            
                    return authorize = false;
            
                    }
