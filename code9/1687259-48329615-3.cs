    class Program
    {
        static void Main(string[] args)
        {
            var wrapper = new Wrapper();
            wrapper.Start();
            System.Console.WriteLine($"{wrapper.data[15]}");
        }
    }
