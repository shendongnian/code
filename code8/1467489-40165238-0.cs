    // Build parameters.
    StringBuilder param = new StringBuilder();
    string exportScript = @"C:\script.scr";
    if (!string.IsNullOrWhiteSpace(exportScript))
    { param.AppendFormat(" /s \"{0}\"", exportScript); }
    
    // Create Process & set the parameters.
    Process acadProcess = new Process();
    acadProcess.StartInfo.FileName = AcadExePath;
    acadProcess.StartInfo.Arguments = param.ToString();
    acadProcess.Start();
