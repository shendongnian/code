    //Approach 1
    public void Run()
    {
        var products = Repository.GetAll().ToList();
        foreach (var product in products)
            Repository.AddEvent();
    }
    //Having condition in IQuerable
    public void Run()
    {
        var products = Repository
                      .GetAll();
                      .Where(someCondition)
                      .OrderBy(SomeOrder)
                      .ToList(); //At this point ef will materialize the query 
                      //and process in sql and you will get the 
                      //result applying this condition at SQL.
        foreach (var product in products)
            Repository.AddEvent();
    }
