    bg.RunWorkerAsync();
    Thread.Sleep(3000);
    if (rpt.HasExited)
    {
        return;
    }
    LaunchedHandle = rpt.MainWindowHandle;
    BackgroundWorker bgPipe = new BackgroundWorker();
    bgPipe.DoWork += new DoWorkEventHandler((o, e) => {
        while (!rpt.HasExited)
        {
            string testHandle = ReadPipe();
            if (testHandle.StartsWith("at loaded evt: "))
            {
                Debug.WriteLine(testHandle);
                Debug.WriteLine("CallBack from Launched Process!");
                var handle = testHandle.Replace("at loaded evt: ","");
                LaunchedHandle = new IntPtr(int.Parse(handle));
                return;
            }
            LaunchedHandle = rpt.MainWindowHandle;
            Thread.Sleep(500);
        }
        Debug.WriteLine("Process exited!");
    });
    bgPipe.RunWorkerAsync();
    CanLaunchCmd = true;
