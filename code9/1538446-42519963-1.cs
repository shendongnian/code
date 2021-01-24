    static class DebugLog
    {
        static public bool DebugMode = true;
        static public void Write(Func<string> f)
        {
            if (DebugMode) Console.WriteLine(f);
        }
    }
