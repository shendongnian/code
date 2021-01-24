        /// <summary>
        /// This will run the EXE for the user. If arguments are passed, then arguments will be used.
        /// </summary>
        /// <param name="incomingShortcutItem"></param>
        /// <param name="xtraArguments"></param>
        public static void RunEXE(string incomingExePath, List<string> xtraArguments = null)
        {
            if (File.Exists(incomingExePath))
            {
                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                System.Diagnostics.Process proc = new System.Diagnostics.Process();
                if (xtraArguments != null)
                {
                    info.Arguments = " " + string.Join(" ", xtraArguments);
                }
                info.WorkingDirectory = System.IO.Path.GetDirectoryName(incomingExePath);
                info.FileName = incomingExePath;
                proc.StartInfo = info;
                proc.Start();
            }
            else
            {
                //do your else thing here
            }
        }
