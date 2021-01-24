    public class Student
    {
        public string Name { get; set; }
        public List<Course> Courses { get; set; } = new List<Course>();
        public class Course
        {
            public string Name { get; set; }
            public string Code { get; set; }
        }
    }
    var student = new Student
    {
        Name = "Jack",
        Courses = new List<Student.Course>
        {
            new Student.Course() {Name = "MATH", Code = "MA"},
            new Student.Course() {Name = "Science", Code = "SC"}
        }
    };
    var str = JsonConvert.SerializeObject(student);
    var studentDeserialized = JsonConvert.DeserializeObject<Student>(str);
