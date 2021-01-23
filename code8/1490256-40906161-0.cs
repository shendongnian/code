    List<Student> result = data.GroupBy(x => new { x.StudentID, x.StrudentName }, 
                (key, group) => new Student{ 
                                              StudentId = key.StudentID, 
                                              StudentName = key.StrudentName,                
                                              Courses = GetCourses(group)}).ToList();
        //You can do this operation with Reflection if you want. If you don't want to write manually the property names.
        public static List<Course> GetCourses(IEnumerable<RawData> data)
        {
            List<Course> course = new List<Course>();
            foreach(var item in data)
            {
                Course c = new Course();
                c.CourseDuration = item.CourseDuration;
                c.CourseId = item.CourseID;
                c.CourseName = item.CourseName;
                course.Add(c);
            }
            return course;
        }
