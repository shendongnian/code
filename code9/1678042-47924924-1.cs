    public class Debug
    {
        // this will be optimized away if "DEBUG" symbol is not defined 
        // in project build properties
        [System.Diagnostics.Conditional("DEBUG")]
        public static void WriteLine(string message) { ... }
    }
    
    public class Trace
    {
        // this will be optimized away if "TRACE" symbol is not defined 
        // in project build properties
        [System.Diagnostics.Conditional("TRACE")]
        public static void WriteLine(string message) { ... }
    }
