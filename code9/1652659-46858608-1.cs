    public static class RuntimeIdentifier
    {
        public static string Value { get; } = DateTime.Now.ToString("yyyyMMddhhmmss");
        // Notice this is NOT the same as:
        //
        //   public static string Value { get { return DateTime.Now.ToString("yyyyMMddhhmmss"); } }
        //
        // which will return a NEW value each time you access it
    }
