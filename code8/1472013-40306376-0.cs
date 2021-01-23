    class Program
    {
        static void Main(string[] args)
        {
            var brazil = new CultureInfo("pt-BR");
            var usa = new CultureInfo("en-US");
            
            Console.WriteLine(100.0018m.ToString(brazil.NumberFormat));
            Console.WriteLine(100.0018m.ToString(usa.NumberFormat));
            Console.ReadKey();
        }
    }
