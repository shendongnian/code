    class FindHostedProcess
    {
        public Timer MyTimer { get; set; }
        private Process _realProcess;
        public FindHostedProcess()
        {
            MyTimer = new Timer(TimerCallback, null, 0, 1000);
            Console.ReadKey();
        }
        private void TimerCallback(object state)
        {
            var foregroundProcess = Process.GetProcessById(WinAPIFunctions.GetWindowProcessId(WinAPIFunctions.GetforegroundWindow()));
            if (foregroundProcess.ProcessName == "ApplicationFrameHost")
            {
                foregroundProcess = GetRealProcess(foregroundProcess);
            }
            Console.WriteLine(foregroundProcess.ProcessName);
        }
        private Process GetRealProcess(Process foregroundProcess)
        {
            WinAPIFunctions.EnumChildWindows(foregroundProcess.MainWindowHandle, ChildWindowCallback, IntPtr.Zero);
            return _realProcess;
        }
        private bool ChildWindowCallback(IntPtr hwnd, IntPtr lparam)
        {
            var process = Process.GetProcessById(WinAPIFunctions.GetWindowProcessId(hwnd));
            if (process.ProcessName != "ApplicationFrameHost")
            {
                _realProcess = process;
            }
            return true;
        }
    }
