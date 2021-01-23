        static void Main(string[] args)
        {
            string cur = Environment.CurrentDirectory;
            Console.WriteLine(cur);
            string parent1 = Path.Combine(cur, @"..\");
            Console.WriteLine(new DirectoryInfo(parent1).FullName);
            string parent2 = Path.Combine(cur, @"..\..\");
            Console.WriteLine(new DirectoryInfo(parent2).FullName);
            Console.ReadLine();
        }
