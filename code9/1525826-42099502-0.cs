    public ActionResult Create([Bind(Include = "RoleId,Name,Description,CompanyID")] Role role)
    {
        if (ModelState.IsValid)
        {
            db.Roles.Add(role);
            db.SaveChanges();
            return RedirectToAction("Index", "CompaniesRolesMV");
        }
    
        return View(role);
    }
