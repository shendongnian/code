                for (int i = 0; i <= 642; i++)
                {
                    var n = RandomNumber(43);
                    var _name = names[i];
                    if (!context.Users.Any(u => u.UserName == _name))
                    {
                        var store = new UserStore<ApplicationUser>(context);
                        var manager = new UserManager<ApplicationUser>(store);
                        var user = new ApplicationUser { UserName = _name, Email = _name + "@eturniej.pl", EmailConfirmed = true };
                        user.UserPhoto = bimages[n];
    
                        manager.Create(user, "!Qazxc");
                        ApplicationUser _user = manager.FindByName(_name);
                        if (_user != null)
                            manager.AddToRole(_user.Id, "User");
    
                    }
                }
