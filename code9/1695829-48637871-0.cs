    public ActionResult Index(string search, DateTime? startdate, DateTime? enddate)
    {
        if (Session["StaffName"] != null)
        {
            //original
            DateTime str = DateTime.UtcNow;
            ViewBag.Datetime = str;
            ViewBag.startdate = startdate;
            ViewBag.enddate = enddate;
            var Trips = from x in db.Trips
                    select x;
            if (search != null)
            {
                if (startdate != null && enddate != null)
                {
                    return View(Trips.Where(x =>  x.TripName.Contains(search) || x.Country.Contains(search)  || search == null && (startdate > x.startDate && x.endDate < enddate)).ToList());
                }
                else
                {
                    return View(Trips.Where(x => x.TripName.Contains(search) || x.Country.Contains(search)  || search == null).ToList());
                }
            }
            if (startdate != null && enddate != null)
            {
                return View(Trips.Where(x => startdate > x.startDate && x.endDate < enddate)).ToList());
            }
            return View(Trips.ToList());
        }
    }
