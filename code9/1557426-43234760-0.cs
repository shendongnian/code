    process.StartInfo = processStartInfo;
                            processStartInfo.RedirectStandardError = true;
    
                            stopWatch.Start();
                            //Start the process
                            process.Start();
    
                            string standardError = process.StandardError.ReadToEnd();
    
                            // wait exit signal from the app we called and then close it. 
                            process.WaitForExit();
                            process.Close();
    
                            stopWatch.Stop();
                            TimeSpan ts = stopWatch.Elapsed;
