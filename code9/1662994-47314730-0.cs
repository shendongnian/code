    var kernel1 = new StandardKernel();
    var kernel2 = new StandardKernel();
    kernel1.Bind<IMyClass>().To<MyClass>().InSingletonScope();
    kernel2.Bind<IMyClass>().To<MyClass>().InSingletonScope();
    var myClass1 = kernel1.Get<IMyClass>();
    var myClass2 = kernel2.Get<IMyClass>();
    var same = myClass1 == myClass2;
    Console.WriteLine(same ? "Same" : "Different");
