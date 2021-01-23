    private void OpenUrl(string url)
    {
    	var oldProcessIds = Process.GetProcesses().Select(pr => pr.Id);
    
    	IntPtr handle = OpenApplication(url);
    	if (handle==IntPtr.Zero)
    	{
    		// Find out what Process is new
    		var processes = Process.GetProcesses();
    		var newProcess = processes.Where(pr => !oldProcessIds.Contains(pr.Id));
    		var parent = ParentProcessUtilities.GetParentProcess(newProcess.First().Handle);
    		Program.MoveWindow(parent.MainWindowHandle, 0, 500, 500, 300, true);
    	}
    	else
    	{
    		Program.MoveWindow(handle, 0, 0, 1500, 100, true);
    	}
    }
    
    private IntPtr OpenApplication(string application)
    {
    	var externalApplication = new Process();
    	externalApplication.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
    	externalApplication.StartInfo.FileName = "http://www.example.com";
    	externalApplication.Start();	
    	externalApplication.Refresh();
    	try
    	{
    		externalApplication.WaitForInputIdle();
    		return externalApplication.MainWindowHandle;
    	} catch 
    	{
    		// Cannot get Handle. Application managaes multiple Threads
    		return IntPtr.Zero;
    	}
    }
