    class Program
    {
        static void Main(string[] args)
        {
            string one = "This is text one";
            string two = "This is string text two not string one";
            var coll = two.Split(' ').Select(p => one.Contains(p) ? p : p.ToUpperInvariant());
            
            Console.WriteLine(string.Join(" ", coll)); // This is STRING text TWO NOT STRING one
            Console.ReadKey();
        }
    }
