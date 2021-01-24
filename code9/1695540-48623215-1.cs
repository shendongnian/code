    public static long GetProcessMemory()
    {
    	try
    	{
    		return Process.GetCurrentProcess().PrivateMemorySize64;
    	}
    	catch
    	{    		
			var type = Type.GetType("Windows.System.MemoryManager, Windows, Version=255.255.255.255, Culture=neutral, PublicKeyToken=null, ContentType=WindowsRuntime");
			return Convert.ToInt64(type.GetProperty("AppMemoryUsage", BindingFlags.Public | BindingFlags.Static).GetValue(null, null));
    	}
    }
