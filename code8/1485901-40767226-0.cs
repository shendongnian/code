    class Student
    {
        public string Name { get; }
        public List<Grade> Grades { get; set; }
        public Student(string name)
        {
            Name = name;
            Grades = new List<Grade>();
        }    
    }
    class Grade
    {
        public string Subject { get; set; }
        public string Code { get; set; }
        public int Points { get; set; }
    }
    class Program
    {
        static Dictionary<string, string> lookup = new Dictionary<string, string>
        {
            ["H1"] = "100", ["O1"] = "56", ["H2"] = "88", ["O2"] = "46", ["H3"] = "77",
            ["O3"] = "37", ["H4"] = "66", ["O4"] = "28", ["H5"] = "56", ["O5"] = "20",
            ["H6"] = "46", ["O6"] = "12", ["H7"] = "37", ["O7"] = "0", ["H8"] = "0", ["O8"] = "0",
        };
        static void Main(string[] args)
        {
            Student s = new Student("new student");
            // Accepting value from user 
            while (s.Grades.Count < 6) //amount of grades you want to input
            {
                Grade g = new Grade();
                string points = string.Empty;
                Console.Write("\nEnter your subject:\t");
                //There's no need to convert consoleReadLine to string
                g.Subject = Console.ReadLine().ToUpperInvariant();
                //keep asking while the user doesn't insert a valid grade lookup code
                while (string.IsNullOrEmpty(points))
                {
                    Console.Write("\nEnter your grade:\t");
                    g.Code = Console.ReadLine().ToUpperInvariant();
                    if (!lookup.TryGetValue(g.Code, out points))
                        Console.WriteLine("Wrong Grade Format!");
                    else
                        g.Points = int.Parse(points);
                }
                //points modification condition
                if (g.Subject.Equals("Math", StringComparison.OrdinalIgnoreCase))
                    g.Points += 25;
                //add the grade data to the student's grades
                s.Grades.Add(g);
            }
            Console.Clear();
            //output using a Linq query
            s.Grades.ForEach(g => Console.WriteLine("{0,15}:{1}:{2}", g.Subject, g.Code, g.Points)); 
        }
