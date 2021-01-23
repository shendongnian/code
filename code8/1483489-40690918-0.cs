    public ActionResult Index()
    {
        using (var context = new ApplicationDbContext())
        {
            UserManager<ApplicationUser> UserManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var users = UserManager.Users;
            var roles = new List<string>();
            // retrieve roles for each user
            foreach (var user in users)
            {
                string str = "";
                foreach (var role in UserManager.GetRoles(user.Id))
                {
                    str = (str == "") ? role.ToString() : str + " - " + role.ToString();
                }
                roles.Add(str);
            }
            var model = new HomeViewModel()
            {
                // create view model with these fields
                users = users.ToList(),
                roles = roles.ToList()
            };
            return View(model);
        }
    }
