    [Authorize(Roles = "CustomRole")]
    public ActionResult CustomRoleOnly()
    {
        return View();
    }
