     var processInfo = new ProcessStartInfo(FilePath, ParametersForPowershell)
                {
                    CreateNoWindow = true,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true
                };
                using (var process = Process.Start(processInfo))
                {
                    if (process != null)
                    {
                        process.OutputDataReceived += delegate (object sender, DataReceivedEventArgs e)
                        {
                            if (!string.IsNullOrEmpty(e.Data))
                            {
                               Console.WriteLine(e.Data);
                               //Write To External Log if necessary
                            }
                        };
                        process.BeginOutputReadLine();
                        process.ErrorDataReceived += delegate (object sender, DataReceivedEventArgs e)
                        {
                            if (!string.IsNullOrEmpty(e.Data))
                            {
                                Console.WriteLine($"ERROR: {e.Data}");
                                //Write To External Log if Necessary
                            }
                        };
                        process.BeginErrorReadLine();
                        process.WaitForExit();
                    }
                }
