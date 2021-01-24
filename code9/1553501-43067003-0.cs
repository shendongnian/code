    public ActionResult GetEvents()
    {
        List<Holiday> holidays = conn.Holidays.ToList(); 
        return View(holidays); 
    }
