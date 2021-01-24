    // GET: Student/Details/5
    public ActionResult Details(int? id) {
        if (id == null) {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        var student = db.Students.Find(id);
        if (student == null) {
            return HttpNotFound();
        }
        return View(student);
    }
    public ActionResult Grab(string id) {
        if (id == null)
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        var student = db.Students.FirstOrDefault(x => x.LastName.ToLower() == id.ToLower());
        if (student == null)
            return HttpNotFound();
        return View(student);
    }
