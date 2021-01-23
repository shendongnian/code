    foreach (Process Process in ProcessList)
    {
        try
        {
            string pName = Process.ProcessName;
            DateTime pStartTime = Process.StartTime;
    		TimeSpan pProcTime = Process.TotalProcessorTime;
    		string pThreads = Process.Threads.ToString();
    		int pSessionId = Process.SessionId;
    		int pId = Process.Id;
    		long pRam = Process.VirtualMemorySize64;
    		string pMachineName = Process.MachineName;
    		int pPriority = Process.BasePriority;
    	
    	
    	
    		ProcessTable.Rows.Add(Process.ProcessName
    							 ,Process.StartTime
    							 ,Process.TotalProcessorTime
    							 ,Process.Threads
    							 ,Process.SessionId
    							 ,Process.Id
    							 ,Process.VirtualMemorySize64
    							 ,Process.MachineName
    							 ,Process.BasePriority);
    	}
    	catch(Win32Exception e)
    	{
    		logger.LogWarning($"Error reading process {process.ProcessName}", e.Message);
    	}
    }
