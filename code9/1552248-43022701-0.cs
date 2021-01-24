        static void Main(string[] args)
        {
            List<string> file1 = new List<string>();
            Console.Write("Enter the path to the folder:");
            string path1 = Console.ReadLine();
            file1.AddRange(System.IO.File.ReadAllLines(path1));
            file1.ForEach(line => Console.WriteLine(line));
            Console.ReadKey();
        }
