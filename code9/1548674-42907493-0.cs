    ...
    // Set up
    var context = new ManuallyPumpedSynchronizationContext(); // Comment this
    SynchronizationContext.SetSynchronizationContext(context); // Comment this
    // Run method under test
    var result = MethodToBeTested();
    Debug.Assert(!result.IsCompleted, "Result should not have been completed yet.");
    // Tear down SyncCtx.
    SynchronizationContext.SetSynchronizationContext(null);
    // Advancing time
    ...
