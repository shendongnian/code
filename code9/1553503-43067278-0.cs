    public ActionResult GetEvents()
    {
        List<Holiday> holidays = conn.Holidays.ToList();
        ViewBag.holidaysResult = JsonConvert.SerializeObject(holidays);
        return View();
    }
