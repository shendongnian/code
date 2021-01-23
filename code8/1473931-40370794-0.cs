    if (Math.Abs(DateTime.Now.Subtract(MemUsageLastCheckTime).TotalMinutes) > 5d)
    {
        long UsedMemory;
        //UsedMemory = GC.GetTotalMemory(false); // Not as reliable
        UsedMemory = System.Diagnostics.Process.GetCurrentProcess().PagedMemorySize64;
        if (UsedMemory > 1073741824) // One GB in bytes 1 X 1024 X 1024 X 1024
        {
            GC.Collect(); // Collect all generations
            //GC.Collect(2,GCCollectionMode.Forced);; Or collect a specific generation and force it to run now
        }
        MemUsageLastCheckTime = DateTime.Now;
    }
