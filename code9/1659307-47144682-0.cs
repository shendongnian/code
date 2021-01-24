    class Student
    {
        public int StudentId { get; set; }
        public string Name { get; set; }
        // Note: parameterless constructor here
        public Student()
        {
        }
    
        public Student(Student student)
        {
            StudentId = student.StudentId;
            Name = student.Name;
        }
    }
    static void Main(string[] args)
    {
            Student s = new Student(); // parameter less constructor
            s.StudentId = 1;
            s.Name = "Alex";
           Student s2 = new Student(s);
    }
