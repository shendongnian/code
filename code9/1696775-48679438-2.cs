    class Program
    {
        static void Main(string[] args)
        {
            // Begin composition root
            var kernel = new StandardKernel();
            kernel.Bind<IFileSystem>().To<FileSystem>();
            kernel.Bind<IFileExistanceCheck>().To<FileExistanceChecker>();
            var app = kernel.Get<Foo>();
            // End composition root
            app.Bar();
        }
    }
