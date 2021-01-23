     public ActionResult Index()
        {
            var _courselst = new List<Course>();
            _courselst.Add(new Course { CourseID = 1, Name = "IT", Teacher = new Teacher { Name = "Scot", TeacherID = 1 } });
            _courselst.Add(new Course { CourseID = 2, Name = "ACC", Teacher = new Teacher { Name = "Manj", TeacherID = 2 } });
            _courselst.Add(new Course { CourseID = 3, Name = "MATHS", Teacher = new Teacher { Name = "Demion", TeacherID = 3 } });
            return View(_courselst);
        }
