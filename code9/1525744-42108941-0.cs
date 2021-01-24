     private void executor(string path)
     {
        //Vars
        ProcessStartInfo processInfo;
        Process process;
    
        processInfo = new ProcessStartInfo(path);
        processInfo.CreateNoWindow = true;
        processInfo.UseShellExecute = false;
        processInfo.RedirectStandardError = true;
        processInfo.RedirectStandardOutput = true;
    
        process = Process.Start(processInfo);
    
        process.ErrorDataReceived += new DataReceivedEventHandler((sender, e) =>
        {
            //Handle Errors
        });
    
        process.BeginErrorReadLine();
        
        //Read Stream to end (will block thread until script ended)
        while (!process.StandardOutput.EndOfStream)
        {
            char c = (char)process.StandardOutput.Read();
            
            if (c == '\n')
            {
                _outputList.Add(_lastOutputStringBuilder.ToString());
                _lastOutputStringBuilder.Clear();
                //Handle Output
            }
            else
                _lastOutputStringBuilder.Append(c);
            
        }
    
        //Handle Exit
    }
