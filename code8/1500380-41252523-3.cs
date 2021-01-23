    public const int FILE_MAP_READ = 0x0004;
    static void Main(string[] args)
    {
        if (NativeFunctions.OpenFileMapping(FILE_MAP_READ, false, "DBWIN_BUFFER") != IntPtr.Zero)
        {
            Log("Someone is listening");
        }
        else
        {
            Log("I am here alone");
        }
    }
    private static void Log(string log)
    {
        Debug.WriteLine(log);
        Console.WriteLine(log);
    }
