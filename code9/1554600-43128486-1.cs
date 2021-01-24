        private DateTime cmdGetCreateDate(string path)
        {
            DateTime createDate = new DateTime();
            int lastSlash = path.LastIndexOf(Convert.ToChar("\\"));
            string file = path.Substring(lastSlash + 1);
            string folder = path.Substring(0, lastSlash);
            string cmdexe = @"C:\Windows\System32\cmd.exe";
            string args = @"/c dir /T:C /A:-D """ + folder + "\"";
            
            Process procCreateDate = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = cmdexe,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            procCreateDate.Start();
            string output = procCreateDate.StandardOutput.ReadToEnd();
            if (!output.Contains(file))
            {
                return createDate; //File not found
            }
            string p = @"\b\d{2}/\d{2}/\d{4}\b\s+\d{2}:\d{2} ..";
            Regex rx = new Regex(p);
            Match m = rx.Match(output);
            if (m.Success)
            {
                DateTime.TryParse(m.Value, out createDate);
            }
            return createDate;
        }
        
    private DateTime cmdGetAccessDate(string path)
        {
            DateTime accessDate = new DateTime();
            int lastSlash = path.LastIndexOf(Convert.ToChar("\\"));
            string file = path.Substring(lastSlash + 1);
            string folder = path.Substring(0, lastSlash);
            string cmdexe = @"C:\Windows\System32\cmd.exe";
            string args = @"/c dir /T:A /A:-D """ + folder + "\"";
            Process procCreateDate = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = cmdexe,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            procCreateDate.Start();
            string output = procCreateDate.StandardOutput.ReadToEnd();
            if (!output.Contains(file))
            {
                return accessDate; //File not found
            }
            string p = @"\b\d{2}/\d{2}/\d{4}\b\s+\d{2}:\d{2} ..";
            Regex rx = new Regex(p);
            Match m = rx.Match(output);
            if (m.Success)
            {
                DateTime.TryParse(m.Value, out accessDate);
            }
            return accessDate;
        }
        private long cmdGetSizeBytes(string path)
        {
            long bytes = -1;
            int lastSlash = path.LastIndexOf(Convert.ToChar("\\"));
            string file = path.Substring(lastSlash + 1);
            string folder = path.Substring(0, lastSlash);
            string cmdexe = @"C:\Windows\System32\cmd.exe";
            string args = @"/c dir /A:-D """ + folder + "\"";
            Process procCreateDate = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = cmdexe,
                    Arguments = args,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            procCreateDate.Start();
            string output = procCreateDate.StandardOutput.ReadToEnd();
            if (!output.Contains(file))
            {
                return bytes; //File not found
            }
            string p = @"\d+ " + file;
            Regex rx = new Regex(p);
            Match m = rx.Match(output);
            if (m.Success)
            {
                string[] splitVal = m.Value.Split(Convert.ToChar(" "));
                bytes = Convert.ToInt64(splitVal[0]);
            }
            return bytes;
        }
