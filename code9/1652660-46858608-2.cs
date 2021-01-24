    public static class RuntimeIdentifier
    {
        public static Lazy<string> _identifier = new Lazy<string>(() => DateTime.Now.ToString("yyyyMMddhhmmss"));
        public static string GetValue()
        {
            return _identifier.Value;
        }
    }
