    internal ApplicationUser GetUserById(string id)
        {
            using(var db = new DataContext())
            {
                var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
                
            }
            using(var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(new DataContext())))
            {
               
            }
        }
