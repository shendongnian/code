    public async Task CreateTestUsers() {
    
        var db = new ApplicationDbContext();
        var userStore = new UserStore<ApplicationUser>(db);
        var userManager = new ApplicationUserManager(userStore);
        
        for (var i = 1; i <= 100; i++) {
            var username = "User" + i;
        
            var user = db.Users.FirstOrDefault(u => u.UserName == username);
            if (user == null) {
                user = new ApplicationUser() {
                                UserName = username,
                                Email = username + "@" + username + "." + username,
                                EmailConfirmed = true,
                                LockoutEnabled = false
                            };
        
                var password = username;
                var result = await userManager.CreateAsync(user, password);
            }
        }
    }
