    static class Program
    {
        // list inside your class with the information you need
        private static List<string> fileLines;
        private static void Main(string[] args)
        {
            // call the method to read your file and create the list
            FirstMethod();
            // second method to get a random line, in this case, will return the string
            var result = SecondMethod();
            Console.WriteLine(result);
            Console.ReadLine();
        }
        private static void FirstMethod()
        {
            // with this approach you can load one line per string inside your List<>
            var yourFile = File.ReadAllLines("C:\\test.txt");
            fileLines = new List<string>(yourFile);
        }
        private static string SecondMethod()
        {
            // random number starting with 0 and maximum to your list size
            var rnd = new Random();
            return fileLines[rnd.Next(0, fileLines.Count - 1)];
        }
    }
