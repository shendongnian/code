	string command = @"C:\temp.ps1";
	var fileName = "powershell";
	var args = $"-ExecutionPolicy unrestricted . '{command}'";
	var process = CreateProcess(fileName, args);
	ExecuteProcess(ref process);
	private Process CreateProcess(string fileName, string args)
	{
		return new Process
		{
			StartInfo =
			{
				FileName = fileName,
				Arguments = args,
				RedirectStandardError = true,
				RedirectStandardOutput = true,
				UseShellExecute = false
			}
		};
	}
	private int ExecuteProcess(ref Process proc)
	{
		proc.Start();
		string text = string.Empty;
		string text2 = string.Empty;
		while (!proc.HasExited)
		{
			Thread.Sleep(1000);
			text += proc.StandardOutput.ReadToEnd();
			text2 += proc.StandardError.ReadToEnd();
		}
		proc.WaitForExit();
		text2 += proc.StandardError.ReadToEnd();
		text += proc.StandardOutput.ReadToEnd();
		Console.WriteLine(text);
		Console.WriteLine(text2);
		return proc.ExitCode;
	}
