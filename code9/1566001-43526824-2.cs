    public ActionResult Grab(string studentName)
    {
        if (studentName == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
    
        var student = db.Students.FirstOrDefault(x => x.LastName.ToLower() == studentName.ToLower());
        if (student == null)
            return HttpNotFound();
    
        return View(student);
    }
