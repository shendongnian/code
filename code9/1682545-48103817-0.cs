    try
    {
    // Start the process with the info we specified.
    // Call WaitForExit and then the using statement will close.
    using (Process exeProcess = Process.Start(startInfo))
    {
        output = exeProcess.StandardOutput.ReadToEnd();
        exeProcess.WaitForExit();
    }
    }
    catch(Exception e)
    {
      Console.WriteLine(e.Message);
    }
