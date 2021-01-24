     public ActionResult Run()
        {
            Process p = new Process();
            p.StartInfo.FileName = "C:/Program Files/Java/jdk1.8.0_20/bin/java.exe";
            p.StartInfo.UseShellExecute = false;
            //path to dir
            p.StartInfo.WorkingDirectory = "E:/Atypon/TE1/src";
            //packageName.MainClass
            p.StartInfo.Arguments = "Assignment3.DateTest";
            p.StartInfo.RedirectStandardInput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.CreateNoWindow = true;
            p.StartInfo.RedirectStandardError = true;
            p.Start();
            string result = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            return View("Index",(Object)result);
        }
