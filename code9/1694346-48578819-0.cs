      var tasks = new List<Task<int>>();
      while(enumerator.MoveNext())
      {
        var item = enumerator.Current;
        Task<int> task = new Task<int>(() => ProcessItem(item));
        task.Start();
        tasks.Add(task);
      }
      foreach(Task<int> task in tasks)
      {
        int i = task.Result;
        classList.Add(i);
      }
