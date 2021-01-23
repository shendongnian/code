    var process = Process.GetCurrentProcess();
    Util.WriteHeading("cpu");
    Util.WriteItem("user", process.UserProcessorTime);
    Util.WriteItem("system", process.PrivilegedProcessorTime);
    Util.WriteItem("total CPU", process.TotalProcessorTime);
    Console.WriteLine();
    Util.WriteHeading("memory");
    Util.WriteItem("private", process.PrivateMemorySize64);
    Util.WriteItem("total memory", GC.GetTotalMemory(false));
    var sb = new StringBuilder();
    for (int i = 0; i <= GC.MaxGeneration; i++)
    {
        if (i > 0)
            sb.Append('/');
        sb.Append(GC.CollectionCount(i));
    }
    Util.WriteItem("collection count", sb.ToString());
    Console.WriteLine();
    Console.WriteLine("                          Current             Peak");
    Console.WriteLine("{0,16} {1,16:n0} {2,16:n0}",
        "Paged",
        process.PagedMemorySize64,
        process.PeakPagedMemorySize64);
    Console.WriteLine("{0,16} {1,16:n0} {2,16:n0}",
        "Working Set",
        process.WorkingSet64,
        process.PeakWorkingSet64);
    Console.WriteLine("{0,16} {1,16:n0} {2,16:n0}",
        "Virtual Memory",
        process.VirtualMemorySize64,
        process.PeakVirtualMemorySize64);
    Console.WriteLine();
    Util.WriteHeading("stopwatch");
    Console.WriteLine(stopwatch.Elapsed);
    Console.WriteLine();
