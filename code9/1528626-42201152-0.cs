    #r "DLLs\MyFunction.dll"
    
    using System;
    
    public static void Run(string myEventHubMessage, TraceWriter log)
    {
        MyFunction.Program.Run(myEventHubMessage, log);
    }
