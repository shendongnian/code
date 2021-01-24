    internal static Task InternalStartNew(
        Task creatingTask, Delegate action, object state, CancellationToken cancellationToken, TaskScheduler scheduler,
        TaskCreationOptions options, InternalTaskOptions internalOptions, ref StackCrawlMark stackMark)
    {
        // Validate arguments.
        if (scheduler == null)
        {
            throw new ArgumentNullException("scheduler");
        }
        Contract.EndContractBlock();
        // Create and schedule the task. This throws an InvalidOperationException if already shut down.
        // Here we add the InternalTaskOptions.QueuedByRuntime to the internalOptions, so that TaskConstructorCore can skip the cancellation token registration
        Task t = new Task(action, state, creatingTask, cancellationToken, options, internalOptions | InternalTaskOptions.QueuedByRuntime, scheduler);
        t.PossiblyCaptureContext(ref stackMark);
        t.ScheduleAndStart(false);
        return t;
    }
