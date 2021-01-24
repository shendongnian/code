    public class SampleClass
    {
        private ISqlLitCallService _sqlService;
    
        public SampleClass(ISqliteCallsService sqlService)
        { 
           _sqlService = sqlService;
        }
    
        public ConnectivitySyncMainLHBackgroundingCode()
        {
            _sqliteCallsService.SyncOfflineFeedbacktoServer();
        }
    }
