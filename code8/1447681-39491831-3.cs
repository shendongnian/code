        public class MySettingsService : IMySettingsService
        {
            private readonly MySettings mySettings;
            public MySettingsService (IOptions<MySettings> _mySettings)
            {
                mySettings = _mySettings.Value;
            }
            public string GetName()
            {
                return mySettings.Name; 
            }
        }
