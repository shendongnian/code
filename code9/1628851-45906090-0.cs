    public static class Console
    {
        public static void WriteLine()
        {
            //Specify System.Console instead of just Console
            System.Console.WriteLine("B"); 
        }
    }
    public static class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("A");
        }
    }
