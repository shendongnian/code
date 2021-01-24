    WorkflowApplication wfApp = new WorkflowApplication(<Your WF>);
    // Workflow lifecycle events omitted except idle.
    AutoResetEvent idleEvent = new AutoResetEvent(false);
    wfApp.Idle = delegate(WorkflowApplicationIdleEventArgs e)
    {
        idleEvent.Set();
    };
    // Run the workflow.
    wfApp.Run();
    // Wait for the workflow to go idle before starting the download
    idleEvent.WaitOne();
    // Start the download and resume the bookmark when finished.
    var result = await Task.Run(() => GetAndSave());
    BookmarkResumptionResult result = wfApp.ResumeBookmark(new Bookmark("GetData"), result);
    // Possible BookmarkResumptionResult values:
    // Success, NotFound, or NotReady
    Console.WriteLine("BookmarkResumptionResult: {0}", result);
