    [HttpPost]
    [ValidateAntiForgeryToken]
    [Authorize(Roles = "Administrator, Project Manager, SuperUser")]
    public ActionResult Create([Bind(Include = "Id,Name")] Project project, List<string> Developers, List<string> ProjectManagers)
    {
        if (ModelState.IsValid)
        {
            foreach (var user in Developers)
            {
                project.Users.Add(db.Users.FirstOrDefault(u => u.Id == user));
            }
            foreach (var user in ProjectManagers)
            {
                project.Users.Add(db.Users.FirstOrDefault(u => u.Id == user));
            }
        }
        db.Projects.Add(project);
        db.SaveChanges();
        return RedirectToAction("Index");
    }
