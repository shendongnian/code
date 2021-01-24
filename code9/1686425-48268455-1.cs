    var result = AllCourses.Where(c => c.ClassType == CourseType.IsScience)
                           .Select(c => new { 
                               Course = c, 
                               EnrollmentList = c.Enrollments.Where(x=>x.IsDone || x.IsProgress)
                            });
