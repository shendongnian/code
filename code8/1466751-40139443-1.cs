    public class WorkerRole : RoleEntryPoint
    {
        private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private ManualResetEvent resetEvent = ManualResetEvent(false);
    
        public override void Run()
        {
            try
            {
                Foo.Bar(this.cancellationTokenSource.Token);
            }
            catch (Exception e)
            {
                Logger.Error(e, e.Message);
            }
            finally
            {
                this.resetEvent.Set();
            }
        }
    
        public override void OnStop()
        {
            this.cancellationTokenSource.Cancel();
    
            try
            {
                this.resetEvent.WaitOne();
            }
            catch (Exception e)
            {
                Logger.Error(e, e.Message);
            }
    
            base.OnStop();
        }
    
        // ... OnStart omitted
    }
