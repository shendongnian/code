    public class Program
    {
        public static bool IsStartedWithMain { get; private set; }
    
        public static void Main(string[] args)
        {
            IsStartedWithMain = true;
            ...
        }
    }
