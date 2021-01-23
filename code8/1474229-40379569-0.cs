    class Program
    {
        static void Main(string[] args)
        {
            var request = "request";
            var fooService = new FooService();
            ServiceProxy.Invoke(r => fooService.DoFoo(request), "abc");
            Console.Read();
        }
    }
    class ServiceProxy
    {
        public static void Invoke(Func<TResponse, TRequest> service, TRequest request)
        {
            Console.WriteLine("input:" + request.ToString());
            var response = service(request);
            Console.WriteLine("output:" + response.ToString());
        }
    }
