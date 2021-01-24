    public class Student
    {
        public string Name { get; private set; }
        public int Age { get; private set; }
        public IEnumerable<string> Courses { get; private set; }
        public Student(string name, int age, params string[] courses)
        {
            this.Name = name;
            this.Age = age;
            this.Courses = courses;
        }
    }
