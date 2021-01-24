        public class StudentsController : Controller
                {
                    private readonly CheckBoxListDbConetxt _dbConetxt = new CheckBoxListDbConetxt();
            
            
            [HttpGet]
            public IActionResult CreateStudent()
                    {
            
                        ViewBag.AllCourses = _dbConetxt.Courses.ToList();
                        return View();
                    }
            
                    // POST: Students/Create
                    [HttpPost]
                    [ValidateAntiForgeryToken]
                    public IActionResult CreateStudent(Student student, List<int> selectedCourses)
                    {
                        if (ModelState.IsValid)
                        {
                            if (selectedCourses != null)
                            {
                                foreach (var item in selectedCourses)
                                {
                                    Course course = _dbConetxt.Courses.Find(item);
                                    student.Courses.Add(course);
                                }
                            }
                            
                            _dbConetxt.Students.Add(student);
                            _dbConetxt.SaveChanges();
                            return RedirectToAction("Index");
                        }
            
                        ViewBag.AllCourses = _dbConetxt.Courses.ToList();
                        return View(student);
                    }
    }
