        public string GetVSProgramPath(string filename)
        {
            Process[] plist = Process.GetProcesses();
            foreach (Process theprocess in plist)
            {
                try
                {
                    ProcessModule pm = theprocess.MainModule;
                    if (theprocess.MainModule.ModuleName.Contains("vshost") && theprocess.MainModule.ModuleName.ToLower().Contains(filename.ToLower()))
                    {
                        string path = theprocess.MainModule.FileName;
                        int loc = path.IndexOf(@"\Projects\");
                        return path.Substring(0, path.IndexOf(@"\", loc + 10));                        
                    }
                }
                catch (Exception ex)
                {
                }
            }
            return string.Empty;
        }
