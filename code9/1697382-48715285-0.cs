        // ProccessId's can be gotten by Proccess.GetProcessesByName("Name")
        public static void KillProcessAndChildren(params int[] processIds)
        {
            foreach (var processID in processIds)
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher(
                    "Select * From Win32_Process Where ParentProcessID=" + processID);
                ManagementObjectCollection moc = searcher.Get();
                foreach (ManagementObject mo in moc)
                {
                    KillProcessAndChildren(Convert.ToInt32(mo["ProcessID"]));
                }
                try
                {
                    Process proc = Process.GetProcessById(processID);
                    proc.Kill();
                }
                catch (ArgumentException)
                {
                    // Process already exited.
                }
            }
        }
