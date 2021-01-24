    //Call this extension on the mshta.exe process to get the path of the .hta file
    public static string GetCommandLine(this Process process) {
        var commandLine = new StringBuilder(process.MainModule.FileName);
    
    	commandLine.Append(" ");
    	using (ManagementObjectSearcher searcher = new ManagementObjectSearcher("SELECT CommandLine FROM Win32_Process WHERE ProcessId = " + process.Id)) {
   			foreach (var commandLinePart in searcher.Get()) {
				commandLine.Append(commandLinePart["CommandLine"]);
				commandLine.Append(" ");
			}
		}
    
		return commandLine.ToString();
	}
