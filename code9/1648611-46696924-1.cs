    public ActionResult Profile(string id)
    {
        TempData["guid"] = id;
        return RedirectToAction("Profile");
    }
    public ActionResult Profile()
    {
        Guid guid = Guid.Parse(TempData["guid"]);
        var Profile = unitOfWork.TechnicianRepository.GetByGuidId(guid);
        return View(Profile);
    }
