    Dictionary<Guid, Task> listofTasks = new Dictionary<Guid, Task>();
    
    public Guid StartTask()
    {
        Task myTask = Task.Factory.StartNew(()=> testMethod());
        Guid taskID = Guid.NewGuid();
        listOfTasks.Add(taskID, myTask);
        return taskID;
    }
    public void CancelTask(Guid id)
    {
        // listOfTasks[id].choose_your_own_task_cancellation_adventure()
    }
