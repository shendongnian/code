    if (connectionTask == null ||
        connectionTask.IsCompleted == false &&
        connectionTask.Status != TaskStatus.Running && 
        connectionTask.Status != TaskStatus.WaitingToRun && 
        connectionTask.Status != TaskStatus.WaitingForActivation)
    {
        connectionTask = Task.Factory.StartNew(ConnectionTask);
    }
