    class Program
    {
        // static void Main(string[] args) => DoJob().Wait() C#7.0
        static void Main()
        {
             DoJob().Wait();
        }
    
        private static async Task DoJob()
        {
            MethodA();
            await MethodB1();
            MethodB2();
        }
    
        private static async Task MethodA()
        {
            Console.WriteLine("A");
        }
    
        private static async Task MethodB1()
        {
            Console.WriteLine("B1");
        }
    
        private static void MethodB2()
        {
            Console.WriteLine("B2");
        }
    }
