    class Program
    {
        public static void Main()
        {
            RuntimeIdentifier.Value = DateTime.Now.ToString("yyyyMMddhhmmss");
            // ...
        }
    }
    
    public static class RuntimeIdentifier
    {
        public static string Value { get; set; }
    }
