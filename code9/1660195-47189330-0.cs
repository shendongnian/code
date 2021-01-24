    IList foos = new List<Foo>() { new Foo { Id = 1, Name = "Test" }, new Foo { Id = 1, Name = "Test2" } };
    var fooHistoryType = typeof(FooHistory);
    var listType = typeof(List<>).MakeGenericType(new[] { fooHistoryType });
    var typedHistories = (IList)Activator.CreateInstance(listType);
    mapper.Map(foos, typedHistories);
    Console.WriteLine((typedHistories[0] as FooHistory).Name);    //Test
    Console.WriteLine((typedHistories[1] as FooHistory).Name);    //Test2
    IEnumerable<FooHistory> historyList = typedHistories as IEnumerable<FooHistory>;
    //historyDbSet.AddRange(newHistories);
    Console.ReadLine();
