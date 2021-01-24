    public class Teacher
    {
        public string Name { get; set; }
        public List<Class> Classes { get; set; } = new List<Class>();
    }
    public class Class
    {
        public string Name { get; set; }
        public List<Student> Students { get; set; } = new List<Student>();
    }
    public class Student
    {
        public string Name { get; set; }
    }
    
