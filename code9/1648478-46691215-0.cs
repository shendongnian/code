    public class IdleCheck
    {
        public static int Timeout { get; set; }
        private static DateTime lastAction;
        public static void ReportAction ()
        {
            lastAction = DateTime.UtcNow;
        }
        public bool IsIdle
        {
            get { return (DateTime.UtcNow - lastAction).TotalSeconds > Timeout; 
        }
    }
