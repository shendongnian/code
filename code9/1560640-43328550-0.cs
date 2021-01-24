    class Program
    {
        static void Main(string[] args)
        {
            Wrapper();
            Console.ReadKey();
        }
        static async void Wrapper() {
            try {
                await Test();
            }
            catch {
                Console.WriteLine("exception caught");
            }
        }
        [MyAspect]
        static async Task Test() {
            Console.WriteLine("started");
            await Task.Delay(100);
            Console.WriteLine("second part");
            throw new Exception("exception");
        }
    }
    [PSerializable]
    class MyAspect : OnMethodBoundaryAspect
    {
        public override void OnEntry(MethodExecutionArgs args)
        {
            Console.WriteLine("OnEntry");
        }
        public override void OnSuccess(MethodExecutionArgs args)
        {
            Console.WriteLine("OnSuccess({0})", args.ReturnValue);
        }
        public override void OnExit(MethodExecutionArgs args)
        {
            Console.WriteLine("OnExit");
        }
        public override void OnException(MethodExecutionArgs args)
        {
            Console.WriteLine("OnException({0})", args.Exception.Message);
        }
    }
