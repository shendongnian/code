    public static class Constants
    {
        public static string Selector1 { get { return ReadFromSettings("Selector1"); } }
        public static string Selector2 { get { return ReadFromSettings("Selector2"); } }
        //etc
        // then, code for ReadFromSettings()
    }
