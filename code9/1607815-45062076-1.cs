    while(Process.GetProcessesByName("process_name").Length > 0)
    {
     //keep murderizing process while they are running
     foreach (var process in Process.GetProcessesByName("whatever"))
     {
       process.Kill();
     }
    }
    //Should be free now to delete
