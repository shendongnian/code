    public enum eStateCode
    {
        Running = 'R',
        Terminated = 'T',
        Cancelled = 'C',
    }
    
    public static class DbStateCode
    {
        public static readonly string Running = ((char)eStateCode.Running).ToString();
        public static readonly string Terminated = ((char)eStateCode.Terminated).ToString();
        public static readonly string Cancelled = ((char)eStateCode.Cancelled).ToString();
    }
