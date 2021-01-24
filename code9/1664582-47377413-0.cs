    public static Task<bool> ExecuteBatchFile(string BatchFilePath, string BatchFileDirectory)
            {
                try
                {
                    Task<bool> executeBatchFileTask = Task.Run<bool>(() =>
                    {
                        bool hasProcessExited = false;
                        ProcessStartInfo startInfo = new ProcessStartInfo()
                        {
                            FileName = BatchFilePath,
                            CreateNoWindow = false,
                            UseShellExecute = true,
                            WindowStyle = ProcessWindowStyle.Normal,
                            WorkingDirectory = BatchFileDirectory
                        };
    
                        // Start the process with the info we specified.
                        // Call WaitForExit and then the using-statement will close.
                        using (System.Diagnostics.Process exeProcess = System.Diagnostics.Process.Start(startInfo))
                        {
                            while (!exeProcess.HasExited)
                            {
                                //Do nothing  
                            }
                            hasProcessExited = true;
                        }
    
                        return hasProcessExited;
                    });
                    return executeBatchFileTask;
                }
                catch (Exception ex)
                {
                    throw;
                }
            }
