    //string path = Server.MapPath(@"~\Jar\TextFile1.txt");    //get file path on the top-level of project(eg. ~\folder\xxx)
            string JavaPath = Environment.GetEnvironmentVariable("JAVA_HOME", EnvironmentVariableTarget.Machine); 
            if(string.IsNullOrEmpty(JavaPath)){
             JavaPath = Environment.GetEnvironmentVariable("JAVA_HOME", EnvironmentVariableTarget.User);
            }
            string path = JavaPath + @"\bin\jarsigner.exe";
            var processInfo = new ProcessStartInfo()
            {
                FileName = path,
                CreateNoWindow = true,
                UseShellExecute = false,
                WindowStyle = ProcessWindowStyle.Hidden
            };
            Process proc = Process.Start(processInfo);
            proc.WaitForExit();
            if (proc.ExitCode == 0)
                ViewBag.Message = path + " exec success.";
            else
                ViewBag.Message = path + " exec fail.";
            return View();
