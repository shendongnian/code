    void Main()
    {
        // the order of our registration does not matter.
        var container = new Container();
        container.Register<IDependency1>.For<Dependency1>();
        container.Register<IDependency2>.For<Dependency2>();
        container.Register<IMyClass>.For<MyClass>();
        // then we request our first object like in the first example (MyClass);
        var myClass = container.Resolve<IMyClass>();
        myClass.Run();
    }
