    class Program
    {
        static void Main(string[] args)
        {
            var request = "request";
            var fooService = new FooService();
            ServiceProxy.Invoke(r => fooService.DoFoo(r), request);
            Console.Read();
        }
    }
    class ServiceProxy
    {
        public static void Invoke<TRequest, TResponse>(Func<TRequest, TResponse> service, TRequest request)
        {
            Console.WriteLine("input:" + request.ToString());
            var response = service(request);
            Console.WriteLine("output:" + response.ToString());
        }
    }
