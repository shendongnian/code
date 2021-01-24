    public ActionResult Save(Events changedEvent,FormCollection actionValues)
    {
        ...
        return Json(new {success = true, url = Url.Action("Index", "Home")});
    }
