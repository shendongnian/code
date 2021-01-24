    [AuthorizeRoles(UserRole.SocietyAdmin, UserRole.ClientAdmin)]
    //Your ActionResult here
    public ActionResult Index()
    {
      return View();
    }
