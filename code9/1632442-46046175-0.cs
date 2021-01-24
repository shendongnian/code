        private void TerminateAll()
        {
            foreach (var process in Process.GetProcessesByName("exenamewithoutext"))
            {
                process?.Kill();
            }
        }
