    private static void OpenPaint()
    {
        Process.process = new Process();
        process.StartInfo.FileName = "mspaint.exe";
        process.StartInfo.WindowStyle = "ProcessWindowStyle.Maximized;
        process.Start();
        process.WaitForInputIdle();          // <=== NOTE: added
    }
