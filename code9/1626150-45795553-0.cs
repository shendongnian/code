    var tasks = new List<Task>();
    var task1 = Task.Factory.StartNew(() => FetchData1());
    tasks.Add(task1);
    var task2 = Task.Factory.StartNew(() => FetchData2());
    tasks.Add(task2);
    Task.WaitAll(tasks.ToArray());
