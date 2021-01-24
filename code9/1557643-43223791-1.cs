    public ActionResult Details(int id)
    {
        var details = context.checkIfUserExist(userID);
        if (details == null)
        {
            return RedirectToAction("takeHimSomewhere");
        }
        return View(details);
    }
