    [HttpGet]
    [AllowAnonymous]
    public ActionResult Register()
    {
        ViewBag.CompanyProfiles = util.GetCompanyProfiles();
        return View();
    }
