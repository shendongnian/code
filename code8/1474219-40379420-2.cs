    class Program
    {
        static void Main(string[] args)
        {
            var request = "request";
            var fooService = new FooService();
            ServiceProxy.Invoke(fooService.DoFoo, "abc"); // lose the DoFoo parameter.
            Console.Read();
        }
    }
