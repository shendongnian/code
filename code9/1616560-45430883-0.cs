            Process azureP = new Process
            {
                StartInfo =
             {
            FileName = "explorer.exe",
            Arguments = uncPath,
            UseShellExecute = false,
             },
                EnableRaisingEvents = true,
            };
            azureP.Start();
            azureP.WaitForExit();
            //find the open explorer process
            Process[] CurrentProcess1 = Process.GetProcessesByName("explorer");
            int Explorerprocessid = -1;
            foreach (var item in CurrentProcess1)
            {
                if (azureP.StartTime < item.StartTime)
                {
                    Console.WriteLine(item.Id);
                    Explorerprocessid = item.Id;
                }
            }
            
            while (true)
            {
                Thread.Sleep(5000);
                Process[] CurrentProcess2 = Process.GetProcessesByName("explorer");
                List<int> l1 = new List<int>();
                foreach (var item in CurrentProcess2)
                {
                    l1.Add(item.Id);
                }
                if (l1.Contains(Explorerprocessid))
                {
                    Console.WriteLine("Continue");
                }
                else
                {
                    //Delete the mount 
                    //Process azurePExit = new Process
                    //{
                    //    StartInfo = new ProcessStartInfo
                    //    {
                    //        FileName = "net.exe",
                    //        Arguments = $"use {uncPath} /delete",
                    //        RedirectStandardOutput = true,
                    //        RedirectStandardError = true
                    //    }
                    //};
                    Console.WriteLine("Break");
                    break;
                }
            }
