        var container = new UnityContainer();
        container.AddExtension(new UnityExtension<IFoo>("id", "123"));
        var class1 = container.Resolve<MyClass>();
        var class2 = container.Resolve<MyClass2>();
        // show 123
        Console.WriteLine(class1.Id);  
        // show 123
        Console.WriteLine(class2.Id);
