    private void SetMentorList()
    {
        var mentors = db.Mentor.Where(m => m.CoursesId == courseId).
                                Select(x => new SelectListItem
                                {
                                    Value = x.FullName,
                                    Text = x.FullName,
                                });
        ViewBag.MentorList = mentors;
    }
    public ActionResult SelectMentors(int courseId)
    {
        SetMentorList();
        return View();
    }
    [HttpPost]
    public ActionResult SelectMentors(StudentSelections model)
    {
        if (ModelState.IsValid)
        {
            db.StudentSelection.Add(model);
            db.SaveChanges();
            return RedirectToAction("Index", "Home");
        }
        SetMentorList();
        return View();
    }
