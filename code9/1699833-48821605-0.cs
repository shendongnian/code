    namespace App.WindowsService
    {
        public partial class FileProcessingService : ServiceBase
        {
            #region System Components
    
            private readonly System.Timers.Timer _processingTimer;
            private static readonly Logger Logger = Logger.Get();
    
            #endregion
    
            #region Service Properties
    
            private int _interval;
            private bool Stopped { get; set; } = true;
    
            /// <summary>
            /// Returns the interval for processing
            /// </summary>
            private int Interval
            {
                get
                {
                    if (_interval <= 0)
                    {
                        return _interval = Settings.ServiceInterval;
                    }
    
                    return _interval;
                }
            }
    
            #endregion
    
            #region Constructor
    
            public FileProcessingService()
            {
                InitializeComponent();
                CanShutdown = true;
                _processingTimer = new System.Timers.Timer();
                _processingTimer.Elapsed += ProcessingTimerElapsed;
            }
    
            #endregion
    
            #region Service Events
    
            protected override void OnStart(string[] args)
            {
                _processingTimer.Interval = Interval;
                _processingTimer.Start();
                Stopped = false;
                Logger.Trace("Service Started");
            }
    
            protected override void OnStop()
            {
                _processingTimer.Stop();
                Stopped = true;
                Logger.Trace("Service Stopped");
            }
    
            protected override void OnShutdown()
            {
                OnStop();
                base.OnShutdown();
            }
    
            #endregion
    
            #region Processing Timer Elapsed Event
    
            private void ProcessingTimerElapsed(object sender, System.Timers.ElapsedEventArgs e)
            {
                Logger.MethodEntry();
    
                try
                {
                    _processingTimer.Stop();
                    Process();
                }
                // ReSharper disable once EmptyGeneralCatchClause
                catch
                {
                }
    
                if (!Stopped)
                {
                    _processingTimer.Start();
                }
            }
    
            #endregion
    
            #region Public Methods
    
            public void Process()
            {
                // Call your processing method
            }
    
            #endregion
        }
    }
