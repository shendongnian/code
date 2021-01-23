    public void SendToPrinter(string filePath, string Printer)
            {
                try
                {
                    Process proc = new Process();
                    proc.Refresh();
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    proc.StartInfo.Verb = "printto";
                    proc.StartInfo.FileName = ConfigurationManager.AppSettings["ReaderPath"].ToString();                    
                    proc.StartInfo.Arguments = String.Format("/t \"{0}\" \"{1}\"", filePath, Printer);
                    proc.StartInfo.UseShellExecute = false;
                    proc.StartInfo.CreateNoWindow = true;
                    proc.Start();
                    proc.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                    if (proc.HasExited == false)
                    {
                        proc.WaitForExit(20000);
                    }
                    proc.EnableRaisingEvents = true;
                    proc.Close();
                }
                catch (Exception e)
                {
                }
            }
