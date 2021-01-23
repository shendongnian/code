     private IntPtr OpenPaint()
     {
        Process process = new Process();
        process.StartInfo.FileName = "mspaint.exe";
        process.StartInfo.WindowStyle = ProcessWindowStyle.Maximized;
        process.Start();
        // As suggested by Thread Owner Thread.Sleep so we get no probs with the handle not set yet
        //Thread.Sleep(500); - bad as suggested by @Hans Passant in his post below, 
        // a much better approach would be WaitForInputIdle() as he describes it in his post.         
        process.WaitForInputIdle();
        return process.MainWindowHandle;
     }
