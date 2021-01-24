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
    {
        ready = externApp[0].WaitForInputIdle(30000);
        DateTime readyAt = DateTime.Now;
        TimeSpan ts = readyAt - externApp[0].StartTime;
        MessageBox.Show("Ready after:" + ts.TotalMilliseconds + " ms"); 
    }
