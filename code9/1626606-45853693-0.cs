                var updateOutput = new List<string>();
    			var updateError = new List<string>();
                var updateProcess = new Process
    			{
    				StartInfo = new ProcessStartInfo
    				{
    					FileName = "the path to nuget.exe file",
    					Arguments = "update " + "project path including .csproj file",
    					UseShellExecute = false,
    					RedirectStandardOutput = true,
    					RedirectStandardError = true,
    					CreateNoWindow = true
    				}
    			};
    			updateProcess.Start();
    			while (!updateProcess.StandardOutput.EndOfStream)
    			{
    				updateOutput.Add(updateProcess.StandardOutput.ReadLine());
    			}
    			while (!updateProcess.StandardError.EndOfStream)
    			{
    				updateError.Add(updateProcess.StandardError.ReadLine());
    			}
