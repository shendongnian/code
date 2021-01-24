    var disposables = new List<IDisposable>();
    disposables.Add(new A());
    disposables.Add(new B());
    disposables.Add(new C());
    
    foreach(var thisDisposable in dispsables)
    {
        thisDisposable.Dispose();
    }
