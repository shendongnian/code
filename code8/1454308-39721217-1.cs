    public ActionResult Create([Bind(Include ="StudentId,StudentName,StudentLastName,StudentPhone,StudentAge,StudentEmail,photo")] Student student , HttpPostedFileBase photo)
    {
        if (ModelState.IsValid)
        {
             var fileName=Path.GetFileName(photo.FileName);
             var path=Path.Combine(Server.MapPath("~/Images/") + fileName)
             photo.SaveAs(path);
             db.Students.Add(student);
             db.SaveChanges();
             return RedirectToAction("Index");
        }
        return View(student);
    }
