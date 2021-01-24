    public ActionResult Logoff()
    {
        DoLogOff();
        ControllerContext.Controller.TempData["Message"] = "Success";
        return RedirectToAction("Index", "Home");
    }
