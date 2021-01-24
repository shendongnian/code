    class Program
    {
        static bool _logicTest = false;
        static int[] items = new int[] { 1, 2, 3 };
        static void Main(string[] args)
        {
            _logicTest = true;
            var foo = items.Where(n => _logicTest);
            _logicTest = false;
            Console.WriteLine(foo.Count());
            _logicTest = true;
            Console.WriteLine(foo.Count());
        }
    }
