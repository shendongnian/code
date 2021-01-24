    class Program
    {
        static void Main(string[] args)
        {
            var set = new SortedSet<Student>(new StudentComparer());
            set.Add(new Student {Name = "Test", Score = 10});
            set.Add(new Student { Name = "Tom", Score = 5 });
            set.Add(new Student { Name = "Adam", Score = 90 });
            set.Add(new Student { Name = "Adam", Score = 85 });
            foreach (var setItem in set)
            {
                Debug.WriteLine($@"{setItem.Name} - {setItem.Score}");
            }
            /*  outputs:
                Adam - 85
                Adam - 90
                Test - 10
                Tom - 5
            */
        }
    }
    class Student
    {
        public string Name { get; set; }
        public int Score { get; set; }
    }
    class StudentComparer : IComparer<Student>
    {
        public int Compare(Student x, Student y)
        {
            var result = x.Name.CompareTo(y.Name);
            if (result == 0)
            {
                result = x.Score.CompareTo(y.Score);
            }
            return result;
        }
    }
