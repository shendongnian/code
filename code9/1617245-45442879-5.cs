        using SHDocVw;
        public bool ExistOpenedWindow()
        {
            ShellWindows _shellWindows = new SHDocVw.ShellWindows();
            string processType;
            foreach (InternetExplorer ie in _shellWindows)
            {
                //this parses the name of the process
                processType = Path.GetFileNameWithoutExtension(ie.FullName).ToLower();
                //this could also be used for IE windows with processType of "iexplore"
                if (processType.Equals("explorer") && ie.LocationURL.Contains("C:/"))
                {
                    return true;
                }
            }
            return false;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (proc == null || !ExistOpenedWindow())
            {
                proc = Process.Start("explorer.exe", @"C:\");
            }
        }
