    var myAssembly = Assembly.Load("MyStaticClassAssembly");
    var myType = myAssembly.GetTypes().First(t => t.Name == "MyAbstractType");
    var myTypeInstance = Activator.CreateInstance(myType);  // Asuming has a default constructor 
    var myImplementation = myType.GetProperties()
        .First(p => p.ReflectedType?.Name == "MyAbstractImplementation")
        .GetValue(myTypeInstance);
    var obj = myType.GetMethod("SomeMethod")?.Invoke(
                    myImplementation,
                    new object[]
                    {
                        // Some args
                    });
