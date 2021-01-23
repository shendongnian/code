    /* Wrong demonstration */
    
    var userManagerA = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
    var userFormA = userManagerA.FindByName(User.Identity.Name);
    userFormA.EmailConfirmed = false;
    // some stuff ...
    
    var userManagerB = new ApplicationUserManager(new UserStore<ApplicationUser>(new ApplicationDbContext()));
    // Will product a Exception from EntityFramework
    userManagerB.Update(userFormA);
