    // GET: Student/Details/5
    public ActionResult Details(int? studentId) {
        if (studentId == null) {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        var student = db.Students.Find(studentId);
        if (student == null) {
            return HttpNotFound();
        }
        return View(student);
    }
    public ActionResult Grab(string studentId) {
        if (studentId == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        var student = db.Students.FirstOrDefault(x => x.LastName.ToLower() == studentId.ToLower());
        if (student == null)
            return HttpNotFound();
        return View(student);
    }
