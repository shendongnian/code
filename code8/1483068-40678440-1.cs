    [HttpPost]
    public ActionResult SelectMentors(StudentSelections model)
    {
        if (ModelState.IsValid)
        {
            db.StudentSelection.Add(model);
            db.SaveChanges();
    
    
            return RedirectToAction("Index", "Home");
        }
        //NOTE: You don't need this 'else' because if everything is OK you'll redirect
    
        //At this point, an error has occurred.
    
        //Populate the mentors in the view bag.
        var mentors = db.Mentor.Where(m => m.CoursesId == courseId).
                                Select(x => new SelectListItem
                                {
                                    Value = x.FullName,
                                    Text = x.FullName,
    
                                });
        ViewBag.MentorList = mentors;
     
        //return the view   
        return View();
    }
