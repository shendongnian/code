    public bool RegisterWebsiteUser(ApplicationUser applicationUser)
    {
            string id = applicationUser.Id;
            var userFromDb = context.Users.Find(id);
            this.context.YourUsers.Add(new YourUser {IdentityUser = userFromDB});
            this.context.SaveChanges();
    }
