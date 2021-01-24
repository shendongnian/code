    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);
        public override void Run()
        {
            Trace.TraceInformation("WorkerRoleB is running");
            try
            {
                this.RunAsync(this.cancellationTokenSource.Token).Wait();
            }
            finally
            {
                this.runCompleteEvent.Set();
            }
        }
        public override bool OnStart()
        {
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;
            TelemetryConfiguration.Active.InstrumentationKey = RoleEnvironment.GetConfigurationSettingValue("APPINSIGHTS_INSTRUMENTATIONKEY");
            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.
            bool result = base.OnStart();
            Trace.TraceInformation("WorkerRoleB has been started");
            return result;
        }
        public override void OnStop()
        {
            Trace.TraceInformation("WorkerRoleB is stopping");
            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();
            base.OnStop();
            Trace.TraceInformation("WorkerRoleB has stopped");
        }
        private async Task RunAsync(CancellationToken cancellationToken)
        {
            // TODO: Replace the following with your own logic.
            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
                await Task.Delay(1000);
            }
        }
    }
