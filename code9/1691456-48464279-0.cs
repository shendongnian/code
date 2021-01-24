    static public bool IsProcessRunning(string name)
    {
       foreach (Process clsProcess in Process.GetProcesses()) 
       {
           if (clsProcess.ProcessName.Contains(name))
              {
        		Console.WriteLine(clsProcess.MainModule.FileName);
        		return true;
        	   }
        	 }
        	 return false;
    } 
