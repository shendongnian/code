    static void Main(string[] args)
    {
        Timer t = new Timer(TimerCallback, null, 0, 2000);
    }
    private static void TimerCallback(Object o)
    {
        //I have tried this and it wrote my name.
        System.IO.StreamWriter SaveFile = new System.IO.StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "\\report.txt", true);
        SaveFile.WriteLine("saumil");
        SaveFile.Flush();
        SaveFile.Close();
        ////Process[] processlist = Process.GetProcesses();
        ////foreach (Process theprocess in processlist)
        ////{
        ////    string s = " Process:  " + theprocess.ProcessName;
        ////    SaveFile.WriteLine("saumil");
        ////    SaveFile.Flush();
        ////    SaveFile.Close();
        ////    //SaveFile.WriteLine(s);
        ////}
    }
