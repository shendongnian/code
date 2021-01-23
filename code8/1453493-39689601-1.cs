        var students = repository.Students.Select(m => new StudentViewModel
        {
            Id = m.Id,
            Name = m.Name
        })
        .Where(m => string.IsNullOrEmpty(query) || m.Name.StartsWith(query));
        return Json(students, JsonRequestBehavior.AllowGet);
