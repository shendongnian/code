    public class Student
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Age { get; set; }
        public string Date { get; set; }
        public virtual Department Department { get; set; }
    }
    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Student> Students { get; set; }
    }
