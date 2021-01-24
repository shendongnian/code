    internal static void PollQueue()
    {
        var targetQueue = new MessageQueue(@".\private$\pendingSaveOperations");
        while (true)
        {
            // This waits for a message to arrive on the queue.
            var message = targetQueue.Receive();
            var myObjectToSave = message.Body as MyBigObject;
    
            // Perform the long running save operation
            LongRunningSave(myObjectToSave);
    
            // Once the save operation finishes, you can resume the associated workflow.
            var autoResetEvent = new AutoResetEvent(false);
            var workflowApp = new WorkflowApplication(new Sequence());
            workflowApp.InstanceStore = new SqlWorkflowInstanceStore("server=mySqlServer;initial catalog=myWfDb;...");
            workflowApp.Completed += e => autoResetEvent.Set();
            workflowApp.Unloaded += e => autoResetEvent.Set();
            workflowApp.Aborted += e => autoResetEvent.Set();
    
            // I'm assuming the object to save has a field somewhere that refers the workflow instance that's running it.
            workflowApp.Load(myObjectToSave.WorkflowInstanceId);
            workflowApp.Run();
            autoResetEvent.WaitOne();
        }
    }
    
    private static void LongRunningSave(object myObjectToSave)
    {
        throw new NotImplementedException();
    }
    
    public class MyBigObject 
    {
        public Guid WorkflowInstanceId { get; set; } = Guid.NewGuid();
    }
