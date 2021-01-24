    public static long GetProcessMemory()
    {
    	try
    	{
    		return Process.GetCurrentProcess().PrivateMemorySize64;
    	}
    	catch
    	{
    		var type = Type.GetType("Windows.System.MemoryManager");
    		var instance = Activator.CreateInstance(type);
    		return (long)type.GetProperty("AppMemoryUsage").GetValue(instance, null);
    	}
    }
