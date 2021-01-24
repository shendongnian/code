    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void FailIfRecusrive() {
        var trace = new StackTrace();
        // previous frame is the caller
        var caller = trace.GetFrame(1).GetMethod();
        // inspect the rest
        for (int i = 2; i < trace.FrameCount; i++) {
            if (trace.GetFrame(i).GetMethod() == caller)
                throw new Exception("Recursion detected");
        }            
    }
