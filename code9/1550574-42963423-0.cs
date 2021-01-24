    [HttpPost]
    public ActionResult Profile(ProfileModel Model)
    {
        // do stuff
        RedirectToAction("Index", Model);
    }
