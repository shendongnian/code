    Dictionary<string, List<string>> codes = new Dictionary<string, List<string>>();
    long bytesBefore = GC.GetTotalMemory(true);
    // Code that adds items to your dictionary comes here
    long bytesAfter = GC.GetTotalMemory(true);
    
    // After your method ends:
    GC.AddMemoryPressure((long) (bytesAfter - bytesBefore));
