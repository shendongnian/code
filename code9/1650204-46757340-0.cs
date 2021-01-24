    private static IntPtr ButtonHookCallback(int nCode, IntPtr wParam, IntPtr lParam)
    {
        if (nCode >= 0)
        {
            if (wParam == (IntPtr)WM_RBUTTONDOWN)
            {
                Start();
            }
            else if (wParam == (IntPtr)WM_RBUTTONUP)
            {
                Stop();
            }
        }
        return CallNextHookEx(MainWindow._hookId, nCode, wParam, lParam);
    }
    private static void Satrt()
    {
        _toStop = false;
        while (true)
        {
            if (_toStop)
            {
                _toStop = false;
                return;
            }
            DoTask();
        }
    }
    private static void Stop()
    {
        _toStop = true;
    }
    private static void DoTask()
    {
        // do something
    }
    private static bool _toStop;
