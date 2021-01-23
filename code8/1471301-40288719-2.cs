    public class TaskWrapper
    {
        public class TaskWrapper(string operationID, Task task, CancellationTokenSource cancellationSource)
        {
            this.OperationID = operationID;
            this.Task = task;
            this.CancellationSource = cancellationSource;
        }
        public string OperationID { get; set; }
        public Task Task { get; set; }
        public CancellationSource Token { get; set; }
    }
    
    
    private Dictionary<Guid, TaskWrapper> ListOfTasks = new Dictionary<Guid, TaskWrapper>();
    // populate the list
    
    public void CancelAll(string operation)
    {
        listOfTasks.Where(a => a.OperationID = operation).CancellationSource.Cancel();
    }
