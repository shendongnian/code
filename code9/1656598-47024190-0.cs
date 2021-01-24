        public class Course
        {
            public int CourseID { get; set; }
            public string Name { get; set; }
            public int CourseStatusID { get; set; }
            public int CourseCategoryID { get; set; }
            public DateTime? DeleteDate { get; set; }
        }
        public class CourseLocation
        {
            public int CourseLocationID { get; set; }
            public int CourseID { get; set; }
        }
        public class CourseSchedules
        {
            public int CourseLocationID { get; set; }
            public DateTime EndDate { get; set; }
        }
