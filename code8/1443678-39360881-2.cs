    [ValidateAntiForgeryToken]
    [HttpPost]
    public ActionResult SetOptionForUser(MyModel theModel, FormsCollection collection) 
    {
        var selectedName = theModel.ddSelect;
        return RedirectToAction("AnotherAction", "AnotherController");
    }
