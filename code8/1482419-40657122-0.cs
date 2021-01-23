                DbContext context = db;
                IdentityResult ir;
                var um = new UserManager<ApplicationUser>(
                    new UserStore<ApplicationUser>(context));
                ApplicationUser au = new ApplicationUser();
                au = db.Users.FirstOrDefault(u => u.UserName == uname);
                if (au == null)
                {
                    // add the user
                    var user = new ApplicationUser()
                    {
                        UserName = TrustNoOne("name", uname),
                        Email = TrustNoOne("email", uemail),
                        ProperUserName = TrustNoOne("propername", upropname)
                    };
                    // create a password for the user
                    ir = um.Create(user, upass);
                    // assign the user to a role
                    if (User.IsInRole(urole) != true)
                    {
                        ir = um.AddToRole(user.Id, urole);
                    }
