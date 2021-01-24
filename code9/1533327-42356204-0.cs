    class Program
    {
        static void Main(string[] args)
        {
            var students = new List<Student>()
            {
                new Student()
                {
                    Score = 10,
                    Name = "David"
                },
                new Student()
                {
                    Score = 4,
                    Name = "Nik"
                },
                new Student()
                {
                    Score = 10,
                    Name = "Randy"
                }
            };
            SortedSet<Student> sortedStudents = new SortedSet<Student>(new StudentMultiCriteria());
            foreach (var student in students)
            {
                sortedStudents.Add(student);
            }
            foreach (var sortedStudent in sortedStudents)
            {
                Console.WriteLine(sortedStudent);
            }
        }
    }
    class Student
    {
        public int Score { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"Score {Score}, Name {Name}";
        }
        
    }
    class StudentMultiCriteria : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            // You do the comparison based on different fields here
            return x.Score.CompareTo(y.Score) == 0 ? x.Name.CompareTo(y.Name) : x.Score.CompareTo(y.Score);
        }
    }
