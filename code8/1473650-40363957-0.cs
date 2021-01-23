    [DllImport("native.x86.dll")]
    public static extern int ExtrernalFunc86();
    [DllImport("native.x64.dll")]
    public static extern int ExtrernalFunc64();
    // ....
    if (IntPtr.Size == 8) return ExternalFunc64();
    else return ExternalFunc86();
