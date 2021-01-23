    class Program
    {
    
        static void helperMethod<T>(T input)
        {
            Console.WriteLine(input);
        }
    
        
        static void Main(string[] args)
        {
            helperMethod<string>("hello Ram !");
            helperMethod<int>(1024);
            Console.Read();
        }
    }
