    namespace Microsoft.Samples.Activities.Statements
    {
    
        class Program
        {
            static AutoResetEvent syncEvent = new AutoResetEvent(false);
            static Guid id;
    
            static void Main(string[] args)
            {
                // create the workflow app and add handlers for the Idle and Completed actions
                WorkflowApplication app = new WorkflowApplication(new Sequence1());
    
                //setup persistence
                InstanceStore store = new SqlWorkflowInstanceStore(@"Data Source=.\SQLEXPRESS;Initial Catalog=WF45GettingStartedTutorial;Integrated Security=True");
                InstanceHandle handle = store.CreateInstanceHandle();
                InstanceView view = store.Execute(handle, new CreateWorkflowOwnerCommand(), TimeSpan.FromSeconds(30));
                handle.Free();
                store.DefaultInstanceOwner = view.InstanceOwner;
                app.InstanceStore = store;
    
    
                app.PersistableIdle = delegate(WorkflowApplicationIdleEventArgs e)
                {
                    syncEvent.Set();
                    return PersistableIdleAction.Unload;
    
                };
    
                app.Unloaded = delegate(WorkflowApplicationEventArgs e)
                {
                    syncEvent.Set();
                };
    
                app.Completed = delegate(WorkflowApplicationCompletedEventArgs e)
                {
                    Console.WriteLine("Workflow {0} Completed.", e.InstanceId);
                    syncEvent.Set();
                };
    
                // start the application
                id = app.Id;
                app.Run();
                syncEvent.WaitOne();
    
                // resume bookmark 1
                string text = Console.ReadLine();
                app = new WorkflowApplication(new Sequence1());
                app.InstanceStore = store;
    
                app.PersistableIdle = delegate(WorkflowApplicationIdleEventArgs e)
                {
                    syncEvent.Set();
                    return PersistableIdleAction.Unload;
    
                };
    
                app.Completed = (workflowApplicationCompletedEventArgs) =>
                {
                    Console.WriteLine("WF Bookmark1 has Completed in the {0} state.",
                                      workflowApplicationCompletedEventArgs.CompletionState);
                    syncEvent.Set();
                };
                app.Unloaded = (workflowApplicationEventArgs) =>
                {
                    Console.WriteLine("WF Bookmark1 unloaded");
                    syncEvent.Set();
                };
    
                app.Load(id);
                app.ResumeBookmark("readText", text);
                syncEvent.WaitOne();
    
                // resume bookmark 2
                int number = ReadNumberFromConsole();
                app = new WorkflowApplication(new Sequence1());
                app.InstanceStore = store;
                app.Completed = (workflowApplicationCompletedEventArgs) =>
                {
                    Console.WriteLine("WF Bookmark2 has Completed in the {0} state.",
                                      workflowApplicationCompletedEventArgs.CompletionState);
                    syncEvent.Set();
                };
                app.Unloaded = (workflowApplicationEventArgs) =>
                {
                    Console.WriteLine("WF Bookmark1 unloaded");
                    syncEvent.Set();
                };
    
                app.Load(id);
                app.ResumeBookmark("readNumber", number);
                syncEvent.WaitOne();
                
                Console.WriteLine("");
                Console.WriteLine("Press [ENTER] to exit...");
                Console.ReadLine();
            }           
           
        } 
    }
