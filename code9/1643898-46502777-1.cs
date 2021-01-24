    public partial class MyWindowsServiceWinService : ServiceBase
        {
            private MyWindowsServiceManagementBootstrapper _bootstrapper;
    
            public MyWindowsServiceWinService()
            {
                InitializeComponent();
            }
    
            protected override void OnStart(string[] args)
            {
                try
                {
                    _bootstrapper = new MyWindowsServiceManagementBootstrapper();
                    _bootstrapper.Initialize();
                }
               
                catch (Exception ex)
                {
                    //EventLog.WriteEntry("MyWindowsService can not be started. Exception message = " + ex.GetType().Name + ": " + ex.Message + " | " + ex.StackTrace, EventLogEntryType.Error);               
                }
            }
    
            protected override void OnStop()
            {
    			try
                {
                    _bootstrapper.Dispose();
                }           
                catch (Exception ex)
                {
                    //log...
                }           
            }
        }
    	
    	
