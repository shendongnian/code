    [MethodImpl(MethodImplOptions.NoInlining)]
    public static void LogMsg(string msg)
    {
         var caller = new StackTrace().GetFrames()[1].GetMethod();
         Console.WriteLine($"{caller.DeclaringType}.{caller.Name}: {msg}");
    }
