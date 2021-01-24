    public void Test()
    {
        List<IWorker<IBasic>> workers = new List<IWorker<IBasic>>
        {
        	new Worker<IBasic>(),
        	new AnotherWorker<IBasic>()
        };
        workers[0].Run(new Basic());
    }
