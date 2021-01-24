    public static Process GetParentProcess(Process process)
    {
    	string query = "SELECT ParentProcessId FROM Win32_Process WHERE ProcessId = " + process.Id;
    	using (ManagementObjectSearcher mos = new ManagementObjectSearcher(query))
    	{
    		foreach (ManagementObject mo in mos.Get())
    		{
    			if (mo["ParentProcessId"] != null)
    			{
    				try
    				{
    					var id = Convert.ToInt32(mo["ParentProcessId"]);
    					return Process.GetProcessById(id);
    				}
    				catch
    				{
    				}
    			}
    		}
    	}
    	return null;
    }
