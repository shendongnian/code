    var myTasks = new List<Task>();
    for (int i = 0; i < 255; i++)
    {
        myTasks.add(Task.Factory.StartNew(() => Pinger.Ping(parameters...)));
    }
    
    Tasks.WhenAll(myTasks);
