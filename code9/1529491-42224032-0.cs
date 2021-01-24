    class Program
    {
        static void Main(string[] args)
        {
            IUnityContainer container = new UnityContainer();
            container.RegisterType(typeof(IArithmetic), typeof(Addition));
            var arithmeticHelper = container.Resolve<IArithmetic>();
            int output = arithmeticHelper.DoOperation(5, 2);
            Console.Write(output);
            Console.ReadKey();
        }
    }
