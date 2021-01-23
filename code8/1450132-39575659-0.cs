    public static int StartBackgroundProcess(string fileName, string arguments)
            {
                int processId = INVALID_PROCESS_ID;
                try
                {
                    using (Process p = new Process())
                    {
                        p.StartInfo.FileName = C:\Windows\System32\mspaint.exe";
                        p.StartInfo.Arguments = "";
                        p.StartInfo.UseShellExecute = false;
                        p.Start();
                        processId = p.Id;
                    }
                }
                catch (Exception ex) 
                {
                    Logger.Error(ex);
                }
                return processId;
            }
