    public ActionResult Create()
    {
        ViewBag.CITY_ID = new SelectList(db.LTCITies, "CITY_ID", "CITY_NAME", 1);
        var entry = new Models.TRRESPONDENT
        {
            ENTRY_DATE = DateTime.Now,
            AUDIT_TIME = DateTime.Now,
        };
        return View(entry); // return your model
    }
