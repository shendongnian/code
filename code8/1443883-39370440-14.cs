    public static class MySettings
    {
        public static Sample.General General
        {
            get { return Sample.General.Default; }
        }
        public static Sample.Advanced Advanced 
        {
            get { return Sample.Advanced.Default; }
        }
        public static void ResetAll()
        {
            General.Reset();
            Advanced.Reset();
        }
        public static void SaveAll()
        {
            General.Save();
            Advanced.Save();
        }
    }
