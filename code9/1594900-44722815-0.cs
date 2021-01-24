        private static bool AlreadyRunning()
        {
            Process[] processes = Process.GetProcesses();
            Process currentProc = Process.GetCurrentProcess();
            logger.LogDebug("Current proccess: {0}", currentProc.ProcessName);
            foreach (Process process in processes)
            {
                if (currentProc.ProcessName == process.ProcessName && currentProc.Id != process.Id)
                {
                    logger.LogInformation("Another instance of this process is already running: {pid}", process.Id);
                    return true;
                }
            }
            return false;
        }
