    public void sendkeys(string data)
    {
        send = true;
        Process s = Process.GetProcessById(p.Id);
        while (s.ProcessName == p.ProcessName && send)
        {
            while (send)
            {
                IntPtr h = s.MainWindowHandle;
                SetForegroundWindow(h);
                SendKeys.SendWait(data);
                Thread.Sleep(1000);
                send = false;
            }
        }
    }
