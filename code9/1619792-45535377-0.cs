	static IEnumerable<Process> WindowProcesses()
	{
		foreach(var proc in Process.GetProcesses())
		{
			if(proc.MainWindowHandle != IntPtr.Zero)
			{
				yield return proc;
			}
		}
	}
