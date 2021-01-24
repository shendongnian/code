    class Program
    {
        static void Main(string[] args)
        {
            //Where Hello is a callback, null will be send as an argument to Hello method
            //2000 is a delay in milliseconds, Timeout.Infinite is periodic of calling a method
            Timer timer = new Timer(Hello, null, 2000,Timeout.Infinite);
            Console.ReadKey();
        }
        static void Hello(Object o)
        {
            Console.WriteLine("Hello World");
        }
    }
