    class Program
    {
        static void Main(string[] args)
        {
            var m = new MyCustomClass();
            m.InitializeAsync().Wait();
            Console.WriteLine("Before exit...");
        }
    }
    public class MyCustomClass
    {
        public MyCustomClass()
        {
            // in a constructor you should not do anything async
        }
        public async Task InitializeAsync()
        {
            await Method1();
        }
        private async Task Method1()
        {
            //do some stuff
            await Method2();
            //do some more stuff
        }
    }
