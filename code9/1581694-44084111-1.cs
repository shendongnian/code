    var tasks = new[]
    {
        Task.Factory.StartNew(() => GetSomething1()),
        Task.Factory.StartNew(() => GetSomething2()),
        Task.Factory.StartNew(() => GetSomething3())
    };    
    var things = Task.WhenAll(tasks);
