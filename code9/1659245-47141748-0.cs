    class Program
    {
        static void Main(string[] args)
        {
            string myvar = System.Environment.GetEnvironmentVariable("MyEnvironmentVariable");
            Console.WriteLine(myvar);
        }
    }
