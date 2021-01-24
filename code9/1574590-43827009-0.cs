    public static class DebuggerHelpers
    {
        [Conditional("DEBUG")]
        public static void BreakIfDebugging()
        {
            if (System.Diagnostics.Debugger.IsAttached)
            {
                 System.Diagnostics.Debugger.Break()
            }
        }
    }
