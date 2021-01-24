    Process[] pname = Process.GetProcessesByName("notepad");
    if (pname.Length == 0)
    {
       //The application is not running. Start your process here
    }
    else
    {
       //Your application is running. Do nothing
    }
