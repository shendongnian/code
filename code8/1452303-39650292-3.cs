    public ActionResult Index() {
        var viewModel = new List<CourseViewModel>();
        
        //Either get the viewmodels from a data source or add them yourself
        
        var course = new CourseViewModel() {
            CourseId = 1,
            CourseName = "Maths 101",
            CoursePlace = "Some class room",
            CourseLevel = "1",
            CourseDate = "",
            //..populate other properties
        };
        viewModel.Add(course);
        //repeat to add more courses
        return View(viewModel);
    }
