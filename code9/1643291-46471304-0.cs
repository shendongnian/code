    Process process = new Process();
    try
    {
      process.StartInfo.FileName = fileName // Loader.exe in this case;
      ...
      //other startInfo props 
      ...
      process.StartInfo.RedirectStandardError = true;
      process.StartInfo.RedirectStandardOutput = true;
      process.OutputDataReceived += OutputReceivedHandler //OR (sender, e) => Console.WriteLine(e.Data);
      process.ErrorDataReceived += ErrorReceivedHandler;
      process.Start();
      process.BeginOutputReadline();
      process.BeginErrorReadLine();
      ....
      //other thing such as wait for exit 
    }
