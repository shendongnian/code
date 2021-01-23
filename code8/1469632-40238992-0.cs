        private static void StartReportThread(ProcessStartInfo generateReport)
        {
            Process proc = Process.Start(generateReport);
            while ((proc != null) && !proc.HasExited)
            {
                proc.Refresh();
                workingSet = proc.WorkingSet64;
                Thread.Sleep(50);
            }
        }
