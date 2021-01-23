    [HttpPost]
    public ActionResult SearchbyDates(DateTime? startdate , DateTime? enddate)
    {
        RepositoryClass sample = new RepositoryClass();
        ViewBag.listDetails = sample.GetDetails(startdate, enddate);
        retirn PartialView("Dashboard");
    }
