     public ActionResult DeletingInternal(string title)
        {
            var item = db.Appointments.Where(x => x.Title == title).FirstOrDefault();
        db.Appointments.Remove(item);
        db.SaveChanges(); // this saves the changes
    }
