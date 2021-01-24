    class Program
    {
        static void Main(string[] args)
        {
            var filePath = "SomeFileThatShouldExist.txt";
            // Check configuration
            if (!File.Exists(filePath))
                throw new InvalidOperationException("Invalid configuration");
            // Begin composition root
            var kernel = new StandardKernel();
            kernel.Bind<Foo>().To(new Bar(filePath));
            // Register other services...
            var app = kernel.Get<Foo>();
            // End composition root
            app.Bar();
        }
    }
