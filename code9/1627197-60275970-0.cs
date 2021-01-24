        public static void Exclusion(string path)
        {
            Process process = new Process();
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.WindowStyle = ProcessWindowStyle.Hidden;
            startInfo.WorkingDirectory = @"C:\Windows\System32";
            startInfo.FileName = "cmd.exe";
            startInfo.Arguments = "/user:Administrator \"cmd /K uwfmgr file add-exclusion " + path + "\"";
            process.StartInfo = startInfo;
            process.Start();
        }
        public static void Main(string[] args)
        {
            string path = "C:\\Program Files";
            path = path.Insert(0, "\""); 
            //if there is space in dir/file path,then insert a quotation mark at the begining 
            //if not inserted only C:\Program will be added to exclusion list
            Exclusion(path);         
        }
    
