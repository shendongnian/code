    static class DebugLog
    {
        static public void Write(bool flag, Func<string> f)
        {
            if (flag) Console.WriteLine(f);
        }
    }
