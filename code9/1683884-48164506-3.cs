    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Course> Courses { get; set; }
    }
    public class Course
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Person Teacher { get; set; }
    }
    public class Person
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime? BOD { get; set; }
        public decimal Salary { get; set; }
    }
