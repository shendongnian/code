    internal class Program
    {
        static void Main(string[] args)
        {
            string[] data = "One;Two;Dhree;Four;Vive;Six;Ceven;Eight;Nine;Pen".Split(';');
            var studs = data.Select(d => new Student(d, d.Length < 4 ? "m" : "f")).ToList();
            var l2 = new List<Student>(studs);
            var l3 = studs.Select(s => Student.CopyMe(s));
            Console.WriteLine("Org:");
            Console.WriteLine("    " + string.Join("\n    ", studs));
            Console.WriteLine("'deep':");
            Console.WriteLine("    " + string.Join("\n    ", l2));
            Console.WriteLine("'copied':");
            Console.WriteLine("    " + string.Join("\n    ", l3));
            Console.ReadLine();
        }
    }
    internal class Student
    {
        public Student(string name, string gender)
        {
            Name = name;
            Gender = gender;
        }
        public string Gender { get; set; }
        public string Name { get; set; }
        public static Student CopyMe(Student s)
        {
            return new Student(s.Name, s.Gender);
        }
        public override string ToString()
        {
            return string.Join(" ", new[] { Name, Gender, g.GetId(this, out var firstTime).ToString() });
        }
        private static ObjectIDGenerator g = new ObjectIDGenerator();
    }
