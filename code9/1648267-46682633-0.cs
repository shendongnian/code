    public void findProcess(string processName)
        {
            BackgroundWorker bg = new BackgroundWorker();
            bg.DoWork += (object sender, DoWorkEventArgs e){
                while(true)
                {
                    Process[] process = Process.GetProcesses();
                    foreach(var p in process )
                        if(p.ProcessName.Equals(processName))
                        {
                            // TODO:
                        }
                    Thread.Sleep(1000);
                }            
            };
        }
