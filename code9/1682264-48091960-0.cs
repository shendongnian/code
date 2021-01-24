    [HttpGet]
    public ActionResult SetDataInDataBase()
    {
        ViewBag.jenisList  = new SelectList(db.isengs, "jenis", "jenis");
        return View();
    }
