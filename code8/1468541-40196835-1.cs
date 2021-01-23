    public class CoursesTeacher
    {
        public int Id { get; set; }
    
        public string FullName { get; set; }
    
        public IEnumerable<string> CourseName { get; set; }
    
        public IEnumerable<int> CourseId { get; set; }
    
        public IList<CourseInfoModel> Courses
        {
            get
            {
                if (CourseName == null || CourseId == null || CourseId.Count() != CourseName.Count())
                    throw new Exception("Invalid data"); //courses and ids must have the same number of elements
    
                var list = new List<CourseInfoModel>();
                for (int i = 0; i < CourseName.Count(); i++)
                {
                    list.Add(new CourseInfoModel
                    {
                        IsFirstCourse = i == 0,
                        CourseId = CourseId.ElementAt(i),
                        CourseName = CourseName.ElementAt(i),
                    });
                }
    
                return list;
            }
        }
    }
