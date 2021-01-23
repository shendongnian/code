    var list = new List<Foo>();
    var result = new Foo();
    for(int i = 0; i < 5; i++)
    {
        result = new Foo()
        {
            Name = i.ToString()
        };
        result.Name = i.ToString();
        list.Add(result);
    }
    foreach (var foo in list)
    {
        Console.WriteLine(foo.Name);
    }
