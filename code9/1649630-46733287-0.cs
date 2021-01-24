    public class WorkerRole : RoleEntryPoint
    {
        private readonly CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
        private readonly ManualResetEvent runCompleteEvent = new ManualResetEvent(false);
        private static ActorSystem ActorSystemInstance;
        public override void Run()
        {
            Trace.TraceInformation("Game.State.WorkerRole is running");
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
            ActorSystemInstance = ActorSystem.Create("GameSystem");            
            // Set the maximum number of concurrent connections
            ServicePointManager.DefaultConnectionLimit = 12;
            // For information on handling configuration changes
            // see the MSDN topic at https://go.microsoft.com/fwlink/?LinkId=166357.
            bool result = base.OnStart();
            Trace.TraceInformation("Game.State.WorkerRole has been started");
            return result;
        }
        public override void OnStop()
        {
            ActorSystemInstance.Terminate();
            Trace.TraceInformation("Game.State.WorkerRole is stopping");
            this.cancellationTokenSource.Cancel();
            this.runCompleteEvent.WaitOne();
            base.OnStop();
            Trace.TraceInformation("Game.State.WorkerRole has stopped");
        }
        private async Task RunAsync(CancellationToken cancellationToken)
        {
            var gameController = ActorSystemInstance.ActorOf<GameControllerActor>("GameController");
            while (!cancellationToken.IsCancellationRequested)
            {
                Trace.TraceInformation("Working");
                await Task.Delay(1000);
            }
        }
    }
