    while (!MemoryProfiler.IsActive)
      Thread.Sleep(500);
    
    // do something here #1
    MemoryProfiler.Dump();
    
    // do something here #2.1
    if (MemoryProfiler.CanControlAllocations)
      MemoryProfiler.EnableAllocations();
    // do something here #2.2, here will be collected allocations, but only in start mode
    if (MemoryProfiler.CanControlAllocations)
      MemoryProfiler.DisableAllocations();
    // do something here #2.3
    MemoryProfiler.Dump();
    
    // do something here #3
    MemoryProfiler.Dump();
    
    if (MemoryProfiler.CanDetach)
      MemoryProfiler.Detach();
