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
                Tom - 5
                Test - 10
                Adam - 85
                Adam - 90
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
            var result = x.Score.CompareTo(y.Score); 
            if (result == 0)
            {
                result = x.Name.CompareTo(y.Name);
            }
            return result;
        }
    }
