    /// <summary>
        /// Prüft ob die Anwendung bereits ausgeführt wird.
        /// </summary>
        /// <returns>
        /// <c>true</c> wenn die Anwendung bereits läuft,
        /// anderenfalls <c>false</c>.
        /// </returns>
        /// <remarks>n/a</remarks>
        private static bool AlreadyRunning()
        {
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(
                                    current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location
                        .Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
