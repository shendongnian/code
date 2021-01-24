    public static void Log(string text, [CallerMemberName] string caller = "", [CallerFilePath] string file = "")
    {
       WriteLog(text, caller, file);
    }
    Log("Something happened");
