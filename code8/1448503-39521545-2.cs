    [HttpPost]
    public IActionResult Create(string rolename)
    {
            _db.Roles.Add(new IdentityRole()
            {
                Name = rolename,
                NormalizedName = rolename.ToUpper()
            });
            _db.SaveChanges();
            ViewBag.ResultMessage = "Role created successfully!";
            return RedirectToAction("Index");
    }
