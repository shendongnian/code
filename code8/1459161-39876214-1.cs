    public IActionResult Create() 
    {
        var student = new Student();
        return View(student)
    }
    [HttpPost]
    public IActionResult Create(Student student)
    {
        _studentDb.Add(student);
        _studentDb.SaveChanges();
        // Do whatever you like to finish this action
    }
