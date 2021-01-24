     private Timer timer;
     public void SetUpTimer(DateTime alertTime, string name)
     {
          var progress = new Progress<Exception>((e) =>
                      {
                            // handle exception form timercallback here, or just rethrow it...
                            throw e;
                       });   
            DateTime current = DateTime.Now;
            TimeSpan timeToGo = (alertTime - current);
            timer = new Timer(x => RunReportTask(name, progress),
                     null, timeToGo, Timeout.InfiniteTimeSpan);
        }
        private void RunReportTask(string name, IProgress<Exception> progress)
        {
            try
            {
                Console.WriteLine("\r\n\r\nSTART Task \t\tReport: " + name);
                //DELAY 25 sec
                Task.Delay(25000);
                if(name.Equals("Report A") || name.Equals("Report D") || name.Equals("Report F"))
                {
                    throw new Exception("Task failed!!!");
                }
                else
                {
                    Console.WriteLine("Task: \t\t" + name + "\tDONE.");
                }
            }
            catch(Exception e)
            {
                progress.Report(e);
            }
        }
