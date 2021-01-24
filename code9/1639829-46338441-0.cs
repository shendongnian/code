        public  ActionResult Index()
        {
 
            var proc = new Process
            {
                StartInfo = new ProcessStartInfo
                {
                    FileName = Server.MapPath("/exe/Sum.exe"),
                    //Arguments could be replaced 
                    Arguments = "1 2",
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    CreateNoWindow = true
                }
            };
            proc.Start();
            while (!proc.StandardOutput.EndOfStream)
            {
                string line = proc.StandardOutput.ReadLine();
                // do something with line
                Response.Write( " The result is : " + line);
            }
            //await getResultAsync();
            return View();
        }
