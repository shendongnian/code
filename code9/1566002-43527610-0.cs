    public ActionResult Grab(string studentName)
    {
        // in my experience.. when you're checking a string variable to see if 
        // it is null.. use string.IsNullOrWhiteSpace.. because even though what
        // you're using checks for null.. it doesn't check for white space..
        if(studentName == null) // so change this to if(string.IsNullOrWhiteSpace(studentName)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Student student = db.Students.SingleOrDefault(student => student.LastName.ToLower() == studentName.ToLower()); // convert the comparison strings to all lower case.. hence the the `.ToLower()` methods for more reliable comparison
        if (student == null)
        {
            return HttpNotFound();
        }
        return View(student);
    }
