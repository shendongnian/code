    // Task.Run using null synchronization context.
    SynchronizationContext current = SynchronizationContext.Current; // save it
    try {
      SynchronizationContext.SetSynchronizationContext(null); // null it out for Task.Run.
      Task.Run(myAction);
    } finally {
      // restore it or else firebase will not marshal calls correctly.
      SynchronizationContext.SetSynchronizationContext(current); 
    }
