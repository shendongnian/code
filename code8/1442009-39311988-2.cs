            [HttpGet]
            public PartialViewResult AddEdit(int? id)
            {
                return PartialView("_AddEditCourse", CourseManager.GetCourse(id));
            }
