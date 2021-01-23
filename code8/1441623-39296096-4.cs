    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include="id,firstname,lastname,email,guests,guestfirstname,guestlastname,productInterest,occupancyTimeline,isInvestment,timeSlot,dateSlot")] CP_LC_Preview cp_lc_preview)
    {
        if (ModelState.IsValid)
        {
           db.Data.Add(cp_lc_preview);
           db.SaveChanges();
           var id = cp_lc_preview.Id; 
           return RedirectToAction("Confirm", new { id = id });
        }
       return View(cp_lc_preview);
    }
