    public ActionResult Index(int filter)
    {
        var studentList = new List<Student>{ new Student() { StudentId = 1, Studentname = "aa", Age = 18 } , new Student() { StudentId = 2, Studentname = "bbb",  Age = 21 } };
        return View(studentList.Where(filter => filter.StudentId = filter));
    }
