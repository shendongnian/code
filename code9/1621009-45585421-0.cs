    CommManager manager = new CommManager();
    manager.GetChannel(); 
    // refers to the static field StaticMe.channels which is manager.channels.
    CommManager manager2 = new CommManager();
    manager2.GetChannel();
    // refers to the static field StaticMe.channels which is manager2.channels.
    manager.GetChannel();
    // still exists, now refers to manager2.channels because of StaticMe now being manager2
    // It is not retaining any of the original channels because of the changed reference.
