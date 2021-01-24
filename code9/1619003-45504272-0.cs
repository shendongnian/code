    public static class Program
    {
        public static void Main(string[] args)
        {
            foreach(var arg in args)
            {
                Console.WriteLine("You entered parameter: " + arg);
            }
    
            Console.ReadLine();
        }
    }
