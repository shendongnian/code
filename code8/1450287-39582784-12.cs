    class Program
    {
        static void Main(string[] args)
        {
            // Resolve
            var hello = new Hello(new World());
            // Use
            Console.WriteLine(hello.ToString());
            Console.ReadLine();
        }
    }
