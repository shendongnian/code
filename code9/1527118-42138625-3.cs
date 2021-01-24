    [HttpPost]
    public ActionResult SetSite(MyViewModel model)
    {
        Session["Site"] = model.SelectedSiteId;
        return RedirectToAction("Home");
    }
