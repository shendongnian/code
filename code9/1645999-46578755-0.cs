    class Program
    {
        static void Main(string[] args) => DoJob().Wait()
    
        private static async void DoJob()
        {
            MethodA();
            await MethodB1();
            MethodB2();
        }
    
        private static void MethodA()
        {
            Console.WriteLine("A");
        }
    
        private static async void MethodB1()
        {
            Console.WriteLine("B1");
        }
    
        private static void MethodB2()
        {
            Console.WriteLine("B2");
        }
    }
