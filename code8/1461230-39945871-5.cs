    [AllowAnonymous]
    public ActionResult Register() {
        var roles = db.Roles.Select(r => new { RoleID = r.Id, RoleName = r.Name}).ToList();
        ViewBag.Roles = new SelectList(roles, "RoleID", "RoleName");
        return View();
    }
