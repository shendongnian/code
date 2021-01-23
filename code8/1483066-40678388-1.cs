    public ActionResult SelectMentors(int courseId)
    {
        var mentors = db.Mentor.Where(m => m.CoursesId == courseId).
                                Select(x => new SelectListItem
                                {
                                    Value = x.FullName,
                                    Text = x.FullName,
                                });
        ViewData.Model = new StudentSelections
        {
           MentorList = mentors
        };
        return View();
    }
