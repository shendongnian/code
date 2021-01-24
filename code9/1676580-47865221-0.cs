    public ActionResult Edit(string programid)
    {
        Program program = db.Programs.Find(programid);
        return View(program);
    }
