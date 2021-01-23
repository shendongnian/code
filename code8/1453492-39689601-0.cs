        IQuerable<StudentModel> students = repository.Students.Select(m => new StudentViewModel
        {
            Id = m.Id,
            Name = m.Name
        });
        if (!string.IsNullOrEmpty(query))
        {
             students= students.Where(m => m.Name.StartsWith(query));
        }
        return Json(students, JsonRequestBehavior.AllowGet);
