         public ActionResult Create(int? area, string now, string search, string message)
        {
            ViewBag.Area = new SelectList(CoreList.GetDropdown("UnitArea"), "DropdownId", "Value", area);
            ViewBag.SelectedArea = area;
            var newdate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            IFormatProvider culture = new CultureInfo(CultureInfo.CurrentCulture.Name, true);
            if (!string.IsNullOrWhiteSpace(now))
            {
                DateTime.TryParse(now, culture, DateTimeStyles.AssumeLocal, out newdate);
            }
            ViewBag.dateFilter = newdate.ToString(CultureInfo
                .GetCultureInfo(CultureInfo.CurrentCulture.Name)
                .DateTimeFormat.ShortDatePattern);
            ViewBag.Search = search;
            var attendances = (from p in db.MstUnitDriverPairings
                               join x in db.TrnAttendanceUnits
                               .Where(o => o.PresentDate.Value.Year == newdate.Year &&
                               o.PresentDate.Value.Month == newdate.Month &&
                               o.PresentDate.Value.Day == newdate.Day)
                               on p.UnitId equals x.UnitId into j1
                               from x in j1.DefaultIfEmpty()
                               join v in db.TrnAttendanceUnits.OrderByDescending(o => o.PresentDate).Where(o => o.ClockOut == null && o.PresentDate < newdate)
                               on p.UnitId equals  v.UnitId into jd1
                               from v in jd1.DefaultIfEmpty()
                               join y in db.TrnAttendanceDrivers.Where(o => o.PresentDate == newdate)
                               on p.DriverId equals y.DriverId into j2
                               from y in j2.DefaultIfEmpty()
                               join z in db.TrnAttendanceDrivers.OrderByDescending(o => o.PresentDate).Where(o => o.ClockOut == null && o.PresentDate < newdate)
                                on p.DriverId equals z.DriverId into jd2
                               from z in jd2.DefaultIfEmpty()
                               where (area == null ? true : p.MstUnits.UnitArea == area)
                               && (string.IsNullOrEmpty(search) ? true : p.MstDrivers.DriverName.ToLower().Contains(search.ToLower())
                               || p.MstUnits.PoliceNo.ToLower().Contains(search.ToLower()))
                               && p.MstUnits.UnitPrimary == true
                               select new Attendance
                               {
                                   DriverId = p.DriverId,
                                   DriverName = p.MstDrivers.DriverName,
                                   DriverIn = y.ClockIn == null ? false : true,
                                   DriverOut = y.ClockOut == null ? false : true,
                                   DriverInDate = y.ClockIn,
                                   DriverInDateBefore = z.ClockIn,
                                   DriverOutDate = y.ClockOut,
                                   DriverOutDateBefore = z.ClockOut,
                                   UnitId = p.UnitId,
                                   PoliceNumber = p.MstUnits.PoliceNo,
                                   UnitIn = x.ClockIn == null? false : true,
                                   UnitOut = x.ClockOut == null ? false : true,
                                   UnitInDate = x.ClockIn,
                                   UnitInDateBefore = v.ClockIn,
                                   UnitOutDate = x.ClockOut,
                                   UnitOutDateBefore = v.ClockOut
                               }).ToList();
            
            return View(attendances);
        }
    [HttpPost]
        public ActionResult AttendanceSave(List<Attendance> Models, string presentDate, int? area, string search)
        {
            string message = string.Empty;
            var newdate = new DateTime();
            IFormatProvider culture = new CultureInfo(CultureInfo.CurrentCulture.Name, true);
            
            if (DateTime.TryParse(presentDate, culture, DateTimeStyles.AssumeLocal, out newdate))
            {
                foreach (var item in Models)
                {
                    TrnAttendanceDriver trnAttendanceDriver = db.TrnAttendanceDrivers.FirstOrDefault(o => o.PresentDate == newdate && o.DriverId == item.DriverId);
                    TrnAttendanceUnit trnAttendanceUnit = db.TrnAttendanceUnits.FirstOrDefault(o => o.PresentDate == newdate && o.UnitId == item.UnitId);
                    if (trnAttendanceDriver != null)
                    {
                        if (item.DriverIn && item.DriverInDate != null) trnAttendanceDriver.ClockIn = item.DriverInDate;
                        if (item.DriverOut && item.DriverOutDate != null)
                        {
                            trnAttendanceDriver.ClockOut = item.DriverOutDate;
                            trnAttendanceDriver.Status = false;
                        }
                    }
                    else
                    {
                        if (item.DriverIn)
                        {
                            var newDriverAttendance = new TrnAttendanceDriver();
                            newDriverAttendance.DriverId = item.DriverId;
                            newDriverAttendance.ClockIn = item.DriverInDate;
                            newDriverAttendance.PresentDate = newdate;
                            newDriverAttendance.Status = true;
                            db.TrnAttendanceDrivers.Add(newDriverAttendance);
                        }
                    }
                    if (trnAttendanceUnit != null)
                    {
                        if (item.UnitIn && item.UnitInDate != null) trnAttendanceUnit.ClockIn = item.UnitInDate;
                        if (item.UnitOut && item.UnitOutDate != null)
                        {
                            trnAttendanceUnit.ClockOut = item.UnitOutDate;
                            trnAttendanceUnit.Status = false;
                        }
                    }
                    else
                    {
                        if (item.UnitIn)
                        {
                            var newUnitAttendance = new TrnAttendanceUnit();
                            newUnitAttendance.UnitId = item.UnitId;
                            newUnitAttendance.ClockIn = item.UnitInDate;
                            newUnitAttendance.PresentDate = newdate;
                            newUnitAttendance.Status = true;
                            db.TrnAttendanceUnits.Add(newUnitAttendance);
                        }
                    }
                }
            }
           
            try
            {
                db.SaveChanges();
            }
            catch //(Exception ex)
            {
                throw;
            }
            return RedirectToAction("Index","Transaction/Attendance", new {area, search, message, now = presentDate });
        }
