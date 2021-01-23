    class Program
    {
        static void Main(string[] args)
        {
            // Configure
            var kernel = new StandardKernel();
            kernel.Bind<Hello>().ToSelf();
            kernel.Bind<World>().ToSelf();
            // Resolve
            var hello = kernel.Get<Hello>();
            // Use
            Console.WriteLine(hello.ToString());
            Console.ReadLine();
        }
    }
