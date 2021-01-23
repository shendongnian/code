    public ActionResult Create([Bind(Include ="StudentId,StudentName,StudentLastName,StudentPhone,StudentAge,StudentEmail,photo")] Student student , HttpPostedFileBase photo)
    {
        if (ModelState.IsValid)
        {
             photo.SaveAs(HttpContext.Server.MapPath("~/Images/") + photo.FileName);
             db.Students.Add(student);
             db.SaveChanges();
             return RedirectToAction("Index");
        }
        return View(student);
    }
