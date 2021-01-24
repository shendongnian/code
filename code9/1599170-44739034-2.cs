    public void Test()
    {
        var propertiesToInitialize = new string[] { "MyProperty1", "MyProperty2", "MyProperty4" };
        var modelFactory = new ModelFactory();
        var list = new List<Model>();
        list.Add(modelFactory.Create(propertiesToInitialize, 500));
        Console.WriteLine("MyProperty1  " + list[0].MyProperty1); // 500
        Console.WriteLine("MyProperty2  " + list[0].MyProperty2); // 500
        Console.WriteLine("MyProperty3  " + list[0].MyProperty3); // 0
        Console.WriteLine("MyProperty4  " + list[0].MyProperty4); // 500
        Console.WriteLine("MyProperty5  " + list[0].MyProperty5); // 0 
    }
