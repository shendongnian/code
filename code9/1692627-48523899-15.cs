    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "chimeTimeID,schedule,ChimeTimeStamp")] ChimeTime chimeTime)
    {
        ViewData["schedule"] = new SelectList(db.Schedules, "scheduleID", "ScheduleName", "Select a Schedule");
        ViewBag.schedule = new SelectList(db.Schedules, "scheduleID", "ScheduleName", "Select a Schedule");
        if (ModelState.IsValid)
        {
            chimeTime.ScheduleID = db.Schedules.Find (Int32.Parse (Request ["schedule"]));
            db.ChimeTimes.Add(chimeTime);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        buildChimeJob(chimeTime);
        return View(chimeTime);
    }
    
