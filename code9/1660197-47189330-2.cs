    IList foos = new List<Foo>() { new Foo { Id = 1, Name = "Test" }, new Foo { Id = 1, Name = "Test2" } };
    var fooHistoryType = typeof(FooHistory);
    var listType = typeof(List<>).MakeGenericType(new[] { fooHistoryType });
    var typedHistories = (IList)Activator.CreateInstance(listType);
    mapper.Map(foos, typedHistories);
    //historyDbSet.AddRange(typedHistories);   //Can we add an IList here?
    Console.ReadLine();
