	Stopwatch sw = new Stopwatch();
	sw.Start();
	while (!result.IsCompleted)
	{
		if (sw.EllapsedMilliseconds >= 60000) //60 seconds
		{
			break;
		}
		Console.WriteLine(DateTime.Now + ">> Running script");
	}
	if (!result.IsCompleted)
	{
		ScriptFailed();
		powerShellInstance.Stop();
	}
