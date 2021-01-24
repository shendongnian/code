    public static class IdleCheck
    {
        public static int Timeout { get; set; }
        private static float lastAction;
        public static void ReportAction ()
        {
            lastAction = Time.time;
        }
        public static bool IsIdle
        {
            get { return (Time.time - time) > Timeout; }
        }
    }
