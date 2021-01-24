    using System.ServiceProcess;
    using System.Threading;
    public class ServiceState
    {
        public ServiceState(CancellationToken cancellationToken, WaitHandle waitHandle)
        {
            this.CancellationToken = cancellationToken;
            this.WaitHandle = waitHandle;
        }
        public CancellationToken CancellationToken { get; }
        public WaitHandle WaitHandle { get; }
    }
    public class MyService : ServiceBase
    {
        private readonly Thread serviceThread;
        private readonly CancellationTokenSource cancellationTokenSource;
        private readonly WaitHandle waitHandle;
        public Service()
        {
            serviceThread = new Thread(ThreadProc);
            cancellationTokenSource = new CancellationTokenSource();
            waitHandle = new EventWaitHandle(false, EventResetMode.AutoReset);
        }
        protected override void OnStart(string[] args)
        {
            var state = new ServiceState(cancellationTokenSource.Token, waitHandle);
            serviceThread.Start(state);
        }
        protected override void OnStop()
        {
            cancellationTokenSource.Cancel();
            waitHandle.Set();
        }
        private static void ThreadProc(object state)
        {
            var serviceState = (ServiceState)state;
            do
            {
                serviceState.WaitHandle.WaitOne();
                if (serviceState.CancellationToken.IsCancellationRequested)
                {
                    return; // This will terminate the thread.
                }
                // Thread logic goes here.
            } while (true);
        }
    }
