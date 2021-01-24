    public async Task<IActionResult> Index(int? categoryId)
    {
        var vm=new CourseListVm();
        //Populate the catetory list so that we can use that in UI to build the dropdown
        vm.Categories = _context.Categories
                                .Select(a => new SelectListItem() {Value = a.Id.ToString(), 
                                                                   Text = a.Name})
                                .ToList();
        List<Course> courseList = new List<Course>();
        if(categoryId==null)
        {
          courseList = await _context.Course.ToListAsync()
        }
        else
        {
          courseList = await _context.Course
                         .Where(a=>a.CategoryId==categoryId.Value)
                         .ToListAsync()
        }
        vm.Courses = GetCourseVms(courseList);
        return View(vm);
    }
    private IEnumerable<CourseVm> GetCourseVms(IEnumerable<Course> courses)
    {
        return courses.Select(a=>new CourseVm { Id=a.Id, Name =a.Name});
    }
