    public override void OnResultExecuting(ResultExecutingContext filterContext)
        {
            //Remove domain\ from windows authenticated user. 
            using (CrewLogContext db2 = new CrewLogContext())
            {
                var currentAppUser = HttpContext.Current.User.Identity.Name.Split('\\')[1];
    
                //Get user from db. 
                var appUser = db2.AppUsers.Where(i => i.Id == currentAppUser).Single();
                var currentAppUserLocation = appUser.LocationID;
                //get IsAdmin flag. 
                //TODO not updating in VIEW
                bool currentAppUserIsAdmin = appUser.IsAdmin;
    
                //department related to user. 
                //TODO not updating in VIEW
                var departments = appUser.Departments.ToList();
                filterContext.Controller.ViewBag.AppUserDepartments = new SelectList(departments, "Id", "Name");
    
                //Flag tells me if current user is ADMIN
    
                filterContext.Controller.ViewBag.AppUserIsAdmin = currentAppUserIsAdmin;
                filterContext.Controller.ViewBag.AppUserLocation = currentAppUserLocation;
            }
        }
