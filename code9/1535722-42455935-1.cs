    public class Student
    {
        public string Name { get; private set; }
        public IEnumerable<string> Courses { get; private set; }
        public Student(string name, params string[] courses)
        {
            this.Name = name;
            this.Courses = courses;
        }
    }
