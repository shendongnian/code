    public static class Constants
    {
        public static int A { get { return 1; } }
        public static int B { get { return 2; } }
        public static int C { get { return 2; } }
        public static int x5000 { get { return 5000; } }
    }
    public enum EConst
    {
        A = 1,
        B, // <= value is 2
        C, // <= value is 3
        x5000 = 5000,
    }
