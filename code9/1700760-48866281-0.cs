    public void StartProcess()
    {
       var myProcessStartInfo = new ProcessStartInfo()
       {
           UseShellExecute = false,
           FileName = exePath,
           CreateNoWindow = false,
           ErrorDialog = true
       };
       var process = new Process();
       process.StartInfo = myProcessStartInfo;
       process.EnableRaisingEvents = true;
       process.OutputDataReceived += function;
       process.BeginOutputReadLine();
       process.WaitForExit();
    }
        
    public void function() 
    {
       this.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(() => { listview.Items.add(newItem);}));
    }
