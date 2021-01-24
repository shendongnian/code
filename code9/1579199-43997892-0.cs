    public ActionResult Details(string id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        int number;
        Instructor instructor;
        bool isInt = Int32.TryParse(id, out number);
        if (IsInt)
        {
            instructor = db.Instructors.Where(x => x.InstructorId == number).SingleOrDefault();
        }
        else
        {
            instructor = db.Instructors.Where(x => x.faculty_name.Equals(id)).SingleOrDefault();
        }
        if (instructor == null)
        {
            return HttpNotFound();
        }
        ViewBag.faculty_active = MyCustomFunctions.UserActivity();
        return View(instructor);
    }
