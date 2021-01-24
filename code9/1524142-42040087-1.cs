    LoadImages(new DirectoryInfo("c:\\Users\\" + Environment.UserName + "\\Desktop\\fireplace"));
    Timer t = new Timer();
    t.Interval = 1000 / 25; // 25 FPS
    t.Tick += WhenTimerTicks;
    t.Start();
