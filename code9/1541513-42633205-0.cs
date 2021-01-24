    public ActionResult Edit(int? id)
    {
         if (id == null)
         {
             return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
         }
         Trailer trailer = db.Trailers.Find(id);
         if (trailer == null)
         {
             return HttpNotFound();
         }
         var list = db.Drivers.ToList();
         list.Insert(0, new Drivers() {driverFullName = "-- Please Select --"});
         ViewBag.DriverID = new SelectList(list, "driverID", "driverFullName"); //showing the list of drivers on edit page
         return View(trailer);
    }
