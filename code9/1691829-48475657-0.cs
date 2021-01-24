    ExecuteCommandBuild("vpncmd", "<server> /server /hub:<hub> /PASSWORD:<psswd> /cmd iptable");
    public void ExecuteCommandBuild(string fileName, string arguments)
            {
    
                try
                {
    
                    System.Diagnostics.ProcessStartInfo procStartInfo =
                    new System.Diagnostics.ProcessStartInfo(fileName, arguments); 
                    procStartInfo.RedirectStandardOutput = true;
                    procStartInfo.UseShellExecute = false;               
                    procStartInfo.CreateNoWindow = true;              
                    System.Diagnostics.Process proc = new System.Diagnostics.Process();
                    proc.StartInfo = procStartInfo;
                    proc.Start();              
                    string result = proc.StandardOutput.ReadToEnd();
    
    
    }
