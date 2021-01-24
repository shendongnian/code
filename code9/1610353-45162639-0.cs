    [HttpGet]
    [AllowAnonymous]
    public ActionResult Register(combinedModel model)
    {
        ViewBag.CompanyProfiles = util.GetCompanyProfiles();
        return View(model);
    }
