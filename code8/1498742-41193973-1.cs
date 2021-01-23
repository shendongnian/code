    var student = db.Students.SingleOrDefault(x => x.Id == id);
    var results = new
    {
        FirstName = student.FirstName,
        LastName = student.LastName,
        SchoolName = student.SchoolName,
        Courses = student.Courses.Select(x => new
        {
            Name = x.Name,
            Description = x.Description
        })
    };
    return Json(results);
