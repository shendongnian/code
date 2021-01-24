    private void MakePng()
    {
        string args = "-o" + graphPath + " -Tpng  " + dotPath;
    
        using(Process process = new Process())
        {
            ProcessStartInfo info = new ProcessStartInfo();
            info.FileName = VizGraphPath;
            info.Arguments = args;
            info.UseShellExecute = false;
            info.CreateNoWindow = true;
    
            process.StartInfo = info;
            process.EnableRaisingEvents = true;
            process.Start();
            process.WaitForExit(10*1000); //10 seconds
        }
        UpdateCanvas();
    }
