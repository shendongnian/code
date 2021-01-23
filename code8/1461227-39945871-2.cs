    [AllowAnonymous]
    public ActionResult Register() {
        ViewBag.Roles = new SelectList(db.Roles.ToList(), "Id", "Name");
        return View();
    }
