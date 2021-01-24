	using System.Diagnostics;
	...
	Process process = new Process();
	// Configure the process using the StartInfo properties.
	process.StartInfo.FileName = "path/to/matlab.exe"; //eg. C:\\abc\matlab.exe
	process.StartInfo.Arguments = "-n";  //Optional
	process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
	process.Start();
	process.WaitForExit();// optional, waits here for the process to exit.
