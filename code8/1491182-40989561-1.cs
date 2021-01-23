     private IntPtr OpenPaint()
     {
        Process process = new Process();
        process.StartInfo.FileName = "mspaint.exe";
        process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
        process.Start();
        // As suggested by Thread Owner Thread.Sleep so we get no probs with the handle not set yet
        Thread.Sleep(500);
        return process.MainWindowHandle;
     }
