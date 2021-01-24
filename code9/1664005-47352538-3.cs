    [MethodImpl(MethodImplOptions.NoInlining)]
    // optionally decorate with Conditional to only be used in Debug configuration
    [Conditional("DEBUG")]
    public static void FailIfCallerIsRecursive() {
        var trace = new StackTrace();
        // previous frame is the caller
        var caller = trace.GetFrame(1).GetMethod();
        // inspect the rest
        for (int i = 2; i < trace.FrameCount; i++) {
            // if found caller somewhere up the stack - throw
            if (trace.GetFrame(i).GetMethod() == caller)
                throw new Exception("Recursion detected");
        }            
    }
