    private ConcurrentDictionary<int, Task> Tasks { get; set; }
    private async Task StartTasks()
    {
      for(int i = 0; i < 5; i++)
      {
        Task task = DoWork(null);
        Tasks.TryAdd(task.Id, task);
      }
    }
