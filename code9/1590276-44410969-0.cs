    static System.IO.StreamWriter SaveFile = new System.IO.StreamWriter("report.txt");
        static void Main(string[] args)
        {
            System.Timers.Timer t = new System.Timers.Timer(TimeSpan.FromMinutes((double)60).TotalMilliseconds); //Every minute
            t.AutoReset = true;
            t.Elapsed += new System.Timers.ElapsedEventHandler(your_method);
            t.Start();
        }
        private static void your_method(object sender, ElapsedEventArgs e)
        {
            Process[] processlist = Process.GetProcesses();
            foreach (Process theprocess in processlist)
            {
                string s = " Process:  " + theprocess.ProcessName;
                SaveFile.WriteLine(s);
            }
        }
