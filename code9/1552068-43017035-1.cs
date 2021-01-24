    Process proc = new Process();
    proc.StartInfo.FileName = @"git";
    proc.StartInfo.Arguments = string.Format(@"clone ""{0}"" ""{1}""", repository_address, target_directory);
    proc.StartInfo.UseShellExecute = false;
    proc.StartInfo.CreateNoWindow = true;
    proc.Start();
    proc.WaitForInputIdle();
