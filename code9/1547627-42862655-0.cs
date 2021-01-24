    ProcessStartInfo psi = new ProcessStartInfo();
    psi.FileName = @"D:\temp\MyExternalApp.exe";
    psi.WorkingDirectory = @"D:\temp";
    Stopwatch sw = StopWatch.StartNew();
    Process.Start(psi);
    Process[] externApp = null;
    int cnt = 0;
    bool ready = false;
    while (externApp == null || externApp.Length == 0 || cnt == 600)
    {
        externApp = Process.GetProcessesByName("MyExternalApp");
        Thread.Sleep(100);
        cnt++;
    }
    if(cnt >= 600) 
        MessageBox.Show("Something has gone terribly wrong launching the external app");
    else
        ready = externApp[0].WaitForInputIdle(30000);
    sw.Stop();
    if(!ready)
        MessageBox.Show("Not ready after:" + sw.ElapsedMilliseconds + " ms"); 
    else
        MessageBox.Show("Ready after:" + sw.ElapsedMilliseconds + " ms"); 
