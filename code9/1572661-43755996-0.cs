    public class MyClass
    {
        public static string GetStuff()
        {
            return string.Empty;
        }
    
        // Extension method.
        public static string GetOtherStuff()
        {
            // cannot use any non-public members of MyClass
            return string.Empty;
        }
    }
