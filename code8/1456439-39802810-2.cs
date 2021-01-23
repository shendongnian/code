    public ActionResult Edit()
    {
        var roles = db.Roles; // get the collection of all roles
        var users = db.Users.Include(x => x.Roles); // get the collection of all users including their selected roles
        List<UserVM> model = new List<UserVM>();
        foreach (var user in users)
        {
           UserVM u = new UserVM
           {
               UserName = user.username,
               Roles = roles.Select(x => new RoleVM
               {
                   RoleName = x.Role1
               }).ToList()
           }
           .... // set the IsSelected property of each RoleVM based existing roles
           model.Add(u);
        }
        return View(model);
    }
    [HttpPost]
    public ActionResult Edit(List<UserVM> model)
    {
        // Get the selected roles for each user
        foreach (UserVM user in Model)
        {
            var selectedRoles = user.Roles.Where(x =>x.IsSelected);
