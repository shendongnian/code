    [AllowAnonymous]
    public ActionResult Register() {
        ViewBag.Roles = new SelectList(db.Roles, "RoleID", "RoleName");
        return View();
    }
