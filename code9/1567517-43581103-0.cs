    [HttpPost]
    public ActionResult NewList()
    {
        //clear session variables, load fresh data from API
        return RedirectToAction("List");
    }
    public ActionResult List()
    {
        // whatever needs to happen to display the state
    }
