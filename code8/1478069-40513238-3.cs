    // you need to populate methodsList first with all the methods you want to call, then...
    foreach (IDownloadMethod<IPersistable> method in methodsList)
    {
       Task<IEnumerable<IPersistable>> task = Task.Run(() => method.Download());
       TaskAwaiter<IEnumerable<IPersistable>> awaiter = task.GetAwaiter();
       while (!awaiter.IsCompleted)
       { // busy waiting is terrible.. we know
       }
       IList<IPersistable> genericList = awaiter.GetResult().ToList();
       if (method.RepositoryMethod != null)
       {
          method.RepositoryMethod(genericList);
       }
    }
