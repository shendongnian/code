    public void Run()
    {
        var products = Repository.GetAll().ToList();
        foreach (var product in products)
            Repository.AddEvent();
    }
