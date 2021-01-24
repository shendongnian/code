    void Main()
    {
    	Process process = new Process();
    	string exePath = System.IO.Path.Combine(@"C:\SourceCode\CS\DsSmokeTest\bin\Debug", "DsSmokeTest.exe");
    	process.StartInfo.FileName = exePath;
    	process.StartInfo.WorkingDirectory = @"C:\SourceCode\CS\DsSmokeTest\bin\Debug";
    	process.StartInfo.Arguments = string.Empty;
    	process.StartInfo.UseShellExecute = false;
    	process.StartInfo.RedirectStandardOutput = true;
    	process.OutputDataReceived += (s, e) => Test(e.Data);
    	process.Start();
    	process.BeginOutputReadLine();
    	process.WaitForExit();
    }
    
    // Define other methods and classes here
    public void Test(string input)
    {
    	input.Dump();	
    }
