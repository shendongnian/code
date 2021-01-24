    tasks.Add(Task.Factory.StartNew(() =>
    {
        rs1.Process();
    }).ContinueWith((previousTask) =>
    {
        List<Task> loInnerTasks = new List<Task>();
        loInnerTasks.Add(Task.Run(() => rs5.Process()));
        loInnerTasks.Add(Task.Run(() => rs6.Process()));
        Task.WaitAll(loInnerTasks.ToArray());
    }));
