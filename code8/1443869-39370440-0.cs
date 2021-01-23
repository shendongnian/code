        public static class MySettings
        {
            public static Sample.General General
            {
                get { return Sample.General.Default; }
            }
            public static Sample.Advanced General
            {
                get { return Sample.General.Default; }
            }
        }
    
    Then it's enough to write such code: `MySettings.General.Reset();`
