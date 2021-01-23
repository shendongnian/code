    var student = db.Students.SingleOrDefault(x => x.Id == id);
    var results = new StudentVm
    {
        FirstName = student.FirstName,
        LastName = student.LastName,
        SchoolName = student.School.Name,               
        Courses = student.Courses.Select(x => new StudentVM
        {
            Name = x.Name,
            Desription = x.Name
        }
    };
    return Json(results);
