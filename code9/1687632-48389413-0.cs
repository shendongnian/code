    using (Process process = Process.Start(start))
                    {
                        using (StreamReader reader = process.StandardOutput)
                        {
                            string stderr = process.StandardError.ReadToEnd(); 
    
                            process.WaitForExit();
    
                            string result = reader.ReadToEnd();
    
                            string text = File.ReadAllText(start.WorkingDirectory + "\\t.txt");
