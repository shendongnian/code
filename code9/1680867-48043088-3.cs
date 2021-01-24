    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Application.Utilities;
    
    namespace Application.ExternalServices
    {
        class ExternalServiceHandler: IExternalServiceHandler
        {
            public event EventHandler OnlineModeDetected;
            public event EventHandler OfflineModeDetected;
            
            private static readonly int RUN_ONLINE_DETECTION_SEC = 10;
            private static ExternalServiceHandler instance;
            private Task checkOnlineStatusTask;
            private CancellationTokenSource cancelSource;
            private Exception errorNoConnection;
    
            public static ExternalServiceHandler Instance
            {
                get
                {
                    if (instance == null)
                    {
                        instance = new ExternalServiceHandler();
                    }
                    return instance;
                }
            }
    
            private ExternalServiceHandler()
            {
                errorNoConnection = new Exception("Could not connect to the server.");
            }
    
            public virtual void Execute(Action func)
            {
                if (func == null) throw new ArgumentNullException("func");
    
                try
                {
                    func();
                }
                catch
                {
                    if(offlineModeDetected())
                    {
                        throw errorNoConnection;
                    }
                    else
                    {
                        throw;
                    } 
                }
            }
    
            public virtual T Execute<T>(Func<T> func)
            {
                if (func == null) throw new ArgumentNullException("func");
    
                try
                {
                    return func();
                }
                catch
                {
                    if (offlineModeDetected())
                    {
                        throw errorNoConnection;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
    
            public virtual async Task ExecuteAsync(Func<Task> func)
            {
                if (func == null) throw new ArgumentNullException("func");
    
                try
                {
                    await func();
                }
                catch
                {
                    if (offlineModeDetected())
                    {
                        throw errorNoConnection;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
    
            public virtual async Task<T> ExecuteAsync<T>(Func<Task<T>> func)
            {
                if (func == null) throw new ArgumentNullException("func");
    
                try
                {
                    return await func();
                }
                catch
                {
                    if (offlineModeDetected())
                    {
                        throw errorNoConnection;
                    }
                    else
                    {
                        throw;
                    }
                }
            }
    
            private bool offlineModeDetected()
            {
                bool isOffline = false;
                if (!LocalMachine.isOnline())
                {
                    isOffline = true;
                    Console.WriteLine("-- Offline mode detected (readonly). --");
    
                    // notify all modues that we're in offline mode
                    OnOfflineModeDetected(new EventArgs());
    
                    // start online detection task
                    cancelSource = new CancellationTokenSource();
                    checkOnlineStatusTask = Run(detectOnlineMode, 
                        new TimeSpan(0,0, RUN_ONLINE_DETECTION_SEC), 
                        cancelSource.Token);
                }
                return isOffline;
            }
    
            private void detectOnlineMode()
            { 
                if(LocalMachine.isOnline())
                {
                    Console.WriteLine("-- Online mode detected (read and write). --");
    
                    // notify all modules that we're online
                    OnOnlineModeDetected(new EventArgs());
    
                    // stop online detection task
                    cancelSource.Cancel();
                }
            }
    
            public static async Task Run(Action action, TimeSpan period, CancellationToken cancellationToken)
            {
                while (!cancellationToken.IsCancellationRequested)
                {
                    await Task.Delay(period, cancellationToken);
    
                    if (!cancellationToken.IsCancellationRequested)
                    {
                        action();
                    }    
                }
            }
    
            protected virtual void OnOfflineModeDetected(EventArgs e)
            {
                OfflineModeDetected?.Invoke(this, e);
            }
            protected virtual void OnOnlineModeDetected(EventArgs e)
            {
                OnlineModeDetected?.Invoke(this, e);
            }
        }
    }
