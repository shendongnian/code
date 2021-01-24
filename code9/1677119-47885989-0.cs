    public ActionResult InventoryRecord()
    {
        var currentUserId = User.Identity.GetUserId();
        var newid = db.Students.FirstOrDefault(d => d.UserID == currentUserId);
        if (newid == null)
        {
            newid = db.Students.Create();
            newid.UserID = currentUserId;
            db.Students.Add(newid);
        }
        Student student = db.Students.Find(newid.UserID);
        if (student == null)
        {
            return HttpNotFound();
        }
        
        TestViewModel model = new TestViewModel
        {
            UserID = student.UserId,
            PhoneNumber = student.PhoneNumber,
            //add the rest.
        };
        return View(model);
    }
