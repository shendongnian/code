	var proc = Process.GetProcessesByName("my-server").Single();
	proc.EnableRaisingEvents = true;
	
	proc.Exited += (a, e) =>
	{
        proc = Process.Start(...);  // Restart the process
	};
