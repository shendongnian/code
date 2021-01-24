    class MyLongProgress : IDisposable
    {
         public MyLongProgress()
         {
             for (int i=0; i<maxNrOfParallelProcesses; ++i)
             {
                 var createdBackGroundWorker = this.CreateBackGroundWorker();
                 createdBackGroundWorker.ReportProgress += this.OnProgressReport;
                 backGroundWorkers.Add(createdBackGroundWorker);
             }
         }
         // TODO: implement Disposable pattern that Disposes the background workers
         private readonly List<BackGroundWorker> backGroundWorkers = new List<BackGroundWorker>();
         public void StartLongProcess()
         {
             // start your long progress, which involves starting the backGroundWorkers
             // These backGroundWorkers will report progress via OnProgressReport
         }
         private void OnProgressReport(object sender, ...)
         {
             var myBackGroundWorker = (BackGroundWorker)sender;
             // calculate the actual progress using earlier received progress reports
             MyProgressReport report = ...
             OnReportProgress(report);
         }
         public event EventHandler<MyprogressReport> ReportProgrogress;
         
         protected virtual void OnReportProgress(MyProgressReport report)
         {
             this.ReportProgress?.Invoke(this, report);
         }
    }
    
