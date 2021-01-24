    namespace MySolution.MyWorkflowApp
    {
        using System.Activities;
        using System.Activities.DurableInstancing;
        using System.Activities.Statements;
        using System.Threading;
    
        internal static class Program
        {
            internal static void Main(string[] args)
            {
                var autoResetEvent = new AutoResetEvent(false);
                var workflowApp = new WorkflowApplication(new Sequence());
                workflowApp.InstanceStore = new SqlWorkflowInstanceStore("server=mySqlServer;initial catalog=myWfDb;...");
                workflowApp.Completed += e => autoResetEvent.Set();
                workflowApp.Unloaded += e => autoResetEvent.Set();
                workflowApp.Aborted += e => autoResetEvent.Set();
                workflowApp.Run();
                autoResetEvent.WaitOne();
            }
        }
    }
