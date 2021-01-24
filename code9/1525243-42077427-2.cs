	public ActionResult Create([Bind(Include = "EnrollmentID,CourseID,StudentID")]Enrollment enrollcourse)
	{
		if (ModelState.IsValid)
		{
			if (!IsStudentEnrolled(enrollcourse))
			{
				db.Enrollments.Add(enrollcourse);
				db.SaveChanges();
				TempData["success"] = "Course Enrolled";
				return RedirectToAction("Index");
			}
			else
			{
				TempData["Already"] = "Student Has Already Enrolled This Course";
			}
		}
		
		ViewBag.StudentId = new SelectList(db.People, "ID", "FullName", enrollcourse.StudentID);
		ViewBag.CourseId = new SelectList(db.Courses, "CourseId", "Title", enrollcourse.CourseID);
		return View(enrollcourse);
	}
	
	private bool IsStudentEnrolled(Enrollment enrollcourse)
	{
		return db.Enrollments.Count(u => u.StudentID == enrollcourse.StudentID && u.CourseID == enrollcourse.CourseID) == 0;		
	}
