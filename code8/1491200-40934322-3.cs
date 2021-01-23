    public partial class SampleService : ServiceBase
    {
        /// <summary> 
        /// Designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        /// <summary>
        /// Event log for the service
        /// </summary>
        EventLog serviceLog;
        /// <summary>
        /// Public Constructor for WindowsService.
        /// - Initialization code here.
        /// </summary>
        public SampleService()
        {
            InitializeComponent();
        }
        /// <summary>
        /// The Main Thread: list of services to run.
        /// </summary>
        static void Main()
        {
            ServiceBase[] ServicesToRun;
            ServicesToRun = new ServiceBase[] { new SampleService() };
            ServiceBase.Run(ServicesToRun);
        }
        /// <summary>
        /// Startup code
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            base.OnStart(args);
            //
            // run your own start code here
            //
           serviceLog.WriteEntry("My service started", EventLogEntryType.Information, 0);
        }
        /// <summary>
        /// Stop code
        /// </summary>
        protected override void OnStop()
        {
            //
            // run your own stop code here
            //
           serviceLog.WriteEntry("My service stopped", EventLogEntryType.Information, 0);
            base.OnStop(); 
        }
        /// <summary>
        /// Cleanup code
        /// </summary>
        /// <param name="disposing"></param>
        protected override void Dispose(bool disposing)
        {
            //
            // do disposing here 
            //
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        /// <summary>
        /// Pause code
        /// </summary>
        protected override void OnPause()
        {
            base.OnPause();
            //
            // code to run if service pauses
            //
        }
        /// <summary>
        /// Continue code
        /// </summary>
        protected override void OnContinue()
        {
            base.OnContinue();
            //
            // code tu run when service continues after being paused
            //
        }
        /// <summary>
        /// Called when the System is shutting down
        /// - when special handling 
        ///   of code that deals with a system shutdown, such
        ///   as saving special data before shutdown is needed.
        /// </summary>
        protected override void OnShutdown()
        {
            //
            // code tu run when system is shut down
            //
            base.OnShutdown();
        }
        /// <summary>
        /// If sending a command to the service is needed
        ///   without the need for Remoting or Sockets,
        ///   this method is used to do custom methods.
        ///   int command = 128; //Some Arbitrary number between 128 & 256
        ///   ServiceController sc = new ServiceController("NameOfService");
        ///   sc.ExecuteCommand(command);
        /// </summary>
        /// <param name="command">Arbitrary Integer between 128 & 256</param>
        protected override void OnCustomCommand(int command)
        {
            base.OnCustomCommand(command);
            //
            // handle custom code here
            //
        }
        /// <summary>
        /// Useful for detecting power status changes,
        ///   such as going into Suspend mode or Low Battery for laptops.
        /// </summary>
        /// <param name="powerStatus">The Power Broadcast Status
        /// (BatteryLow, Suspend, etc.)</param>
        protected override bool OnPowerEvent(PowerBroadcastStatus powerStatus)
        {
            //
            // handle power events here
            //
            return base.OnPowerEvent(powerStatus);
        }
        /// <summary>
        /// To handle a change event
        ///   from a Terminal Server session.
        ///   Useful if determining 
        ///   when a user logs in remotely or logs off,
        ///   or when someone logs into the console is needed.
        /// </summary>
        /// <param name="changeDescription">The Session Change
        /// Event that occured.</param>
        protected override void OnSessionChange(SessionChangeDescription changeDescription)
        {
            //
            // handle session change here
            //
            base.OnSessionChange(changeDescription);
        }
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            // first 8 letters should be unique
            this.ServiceName = "SampleService";
            // if you want to log service event to log registered while installing the service
            string newLogName = this.ServiceName + "Log";
            string newSourceName = this.ServiceName;
            if (!EventLog.SourceExists(newSourceName))
            {
                EventLog.CreateEventSource(newSourceName, newLogName);
            }
            serviceLog = new EventLog();
            serviceLog.Source = newSourceName;
            serviceLog.Log = newLogName;
            // Causes log to be disposed when the service is disposed
            components.Add(serviceLog);
            // Flags set whether or not to handle that specific type of event.
            this.CanHandlePowerEvent = true;
            this.CanHandleSessionChangeEvent = true;
            this.CanPauseAndContinue = true;
            this.CanShutdown = true;
            this.CanStop = true;
        }
    }
