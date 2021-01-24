	System.Diagnostics.Process process = new System.Diagnostics.Process();
	string WorkingDirectoryInfo =@"D:\home\site\wwwroot\TimerTriggerCSharp1";
	string ExeLocation = @"D:\home\site\wwwroot\TimerTriggerCSharp1\MyApplication.exe";
	Process proc = new Process();
	ProcessStartInfo info = new ProcessStartInfo();
	try
	{
	info.WorkingDirectory = WorkingDirectoryInfo;
	info.FileName = ExeLocation;
	info.Arguments = "";
	info.WindowStyle = ProcessWindowStyle.Minimized;
	info.UseShellExecute = false;
	info.CreateNoWindow = true;
	proc.StartInfo = info;
	proc.Refresh();
	proc.Start();
	proc.WaitForInputIdle();
	proc.WaitForExit();
	}
	catch
	{
	}
	log.Info($"C# Timer trigger function executed at: {DateTime.Now}");
}
