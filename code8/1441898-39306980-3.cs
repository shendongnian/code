    [HttpGet]
    public ActionResult ConfirmDelete(string fileName)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(string fileName)
