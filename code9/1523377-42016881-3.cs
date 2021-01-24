    [HttpPost]
    public ActionResult Index(StudentVM model)
    {
        var student = new StudentModel();
        student.Name = model.Name;
        ....
        foreach (var subject in model.Subjects)
        {         
            student.Subjects.Add(new SubjectModel() { Subject = subject });
        }
        // Save and redirect
