     ////  // Instantiate the ASP.NET Identity system
                var manager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(new ApplicationDbContext()));
                var currentUser = manager.FindById(User.Identity.GetUserId());
    
    
                // Recover the profile information about the logged in user
              
                ViewBag.description = currentUser.UserName;
