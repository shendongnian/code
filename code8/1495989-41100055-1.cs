    public ActionResult Edit([Bind(Include = "ID,EventName,Room,EventDate,DateToString,EventTime,UserPhone,Status,Guests")] Event @event)
        {
            if (ModelState.IsValid)
            {
                @event.UserName = User.Identity.Name;
                @event.Guests.ForEach(f => db.Entry(f).State = EntityState.Modified);
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(@event);
        }
