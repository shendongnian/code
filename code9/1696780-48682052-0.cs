    public interface IFileExistenceCheckerFactory
    {
        IFileExistenceCheck Create(string path);
    }
    ...
    var kernel = new StandardKernel();
    kernel.Bind<IFileExistenceCheck>().To<FileExistenceChecker>();
    kernel.Bind<IFileSystem>().To<FileSystem>();
    kernel.Bind<IFileExistenceCheckerFactory>().ToFactory(() => new TypeMatchingArgumentInheritanceInstanceProvider());
    var factory = kernel.Get<IFileExistenceCheckerFactory>();
    var checker = factory.Create("SomeMagicString");
    var fileExist = checker.FileExist();
