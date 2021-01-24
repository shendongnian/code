    public static void Start(long campaign_id, long contact_id, string startDate, string endDate, string user)
    {
        try
        {
            ProcessStartInfo startInfo = new ProcessStartInfo(); 
            startInfo.FileName = "cmd.exe";
            startInfo.WorkingDirectory = @"C:\";
            startInfo.Arguments = "/c sparkclr-submit --master " + ConfigurationManager.AppSettings["SparkMaster"] + " --driver-class-path " + AppDomain.CurrentDomain.BaseDirectory + "Engine\\mysql.jar " + "--exe CmAnalyticsEngine.exe " + AppDomain.CurrentDomain.BaseDirectory + "Engine " + campaign_id + " " + contact_id + " " + startDate + " " + endDate + " " + user;
            startInfo.CreateNoWindow = false;
            startInfo.UseShellExecute = false;
            startInfo.LoadUserProfile = true;
            //startInfo.Verb = "runas";
            Process process = new Process();
            process.StartInfo = startInfo;
            process.Start();
            if (!process.HasExited)
            {
                Console.WriteLine("process is running");
            }
            else
            {
                Console.WriteLine("process is stopped");
            }
        }
        catch (Exception e)
        {
            LogWritter.WriteErrorLog(e);
        }
    }
