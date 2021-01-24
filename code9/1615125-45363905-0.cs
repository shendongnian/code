    public ActionResult ControllerToView()
    {
        ...
        TempData["example"] = "this is a message!";
        ...
        // returning view counts as providing response
        return View();
    }
