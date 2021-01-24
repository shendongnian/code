    public ActionResult Index(string search, DateTime? startdate, DateTime? enddate)
    {
        ViewBag.Datetime = DateTime.UtcNow;
        ViewBag.startdate = startdate;
        ViewBag.enddate = enddate;
        
        IQueryable<Trips> trips = db.Trips;
        if (search != null)
        {
            trips = trips.Where(x => x.TripName.Contains(search) || x.Country.Contains(search);
        }
        if (startdate.HasValue)
        {
            trips = trips.Where(x => x.startDate > startdate.Value);
        }
        if (enddate.HasValue)
        {
            trips = trips.Where(x => x.enddate < enddate.Value);
        }
        // At this point the query has generated a SQL statement based on the conditions above,
        // but it will not be executed until the until the next line - i.e. when calling .ToList()
        return View(trips.ToList());
    }
