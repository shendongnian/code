    [HttpPost]
    public ActionResult SetOptionForUser(string selectedPerson)
    {
        string option = selectedPerson;
        return RedirectToAction("AnotherAction", "AnotherController");
    }
