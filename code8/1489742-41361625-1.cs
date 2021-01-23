    public enum AMSI_RESULT
        {
            AMSI_RESULT_CLEAN = 0,
            AMSI_RESULT_NOT_DETECTED = 1,
            AMSI_RESULT_DETECTED = 32768
        }
    [DllImport("Amsi.dll", EntryPoint = "AmsiInitialize", CallingConvention = CallingConvention.StdCall)]
    public static extern int AmsiInitialize([MarshalAs(UnmanagedType.LPWStr)]string appName, out IntPtr amsiContext);
    [DllImport("Amsi.dll", EntryPoint = "AmsiUninitialize", CallingConvention = CallingConvention.StdCall)]
    public static extern void AmsiUninitialize(IntPtr amsiContext);
    [DllImport("Amsi.dll", EntryPoint = "AmsiOpenSession", CallingConvention = CallingConvention.StdCall)]
    public static extern int AmsiOpenSession(IntPtr amsiContext, out IntPtr session);
    [DllImport("Amsi.dll", EntryPoint = "AmsiCloseSession", CallingConvention = CallingConvention.StdCall)]
    public static extern void AmsiCloseSession(IntPtr amsiContext, IntPtr session);
    [DllImport("Amsi.dll", EntryPoint = "AmsiScanString", CallingConvention = CallingConvention.StdCall)]
    public static extern int AmsiScanString(IntPtr amsiContext, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPWStr)]string @string, [InAttribute()] [MarshalAsAttribute(UnmanagedType.LPWStr)]string contentName, IntPtr session, out AMSI_RESULT result);
    [DllImport("Amsi.dll", EntryPoint = "AmsiScanBuffer", CallingConvention = CallingConvention.StdCall)]
    public static extern int AmsiScanBuffer(IntPtr amsiContext, [In] [MarshalAs(UnmanagedType.LPArray)] byte[] buffer, ulong length, [In()] [MarshalAs(UnmanagedType.LPWStr)] string contentName, IntPtr session, out AMSI_RESULT result);
    //This method apparently exists on MSDN but not in AMSI.dll (version 4.9.10586.0)
    [DllImport("Amsi.dll", CharSet = CharSet.Unicode, CallingConvention = CallingConvention.StdCall)]
    public static extern bool AmsiResultIsMalware(AMSI_RESULT result);
    private void CallAntimalwareScanInterface()
    {
        IntPtr amsiContext;
        IntPtr session;
        AMSI_RESULT result = 0;
        int returnValue;
        returnValue = AmsiInitialize("VirusScanAPI", out amsiContext); //appName is the name of the application consuming the Amsi.dll. Here my project name is VirusScanAPI.   
        returnValue = AmsiOpenSession(amsiContext, out session);
        returnValue = AmsiScanString(amsiContext, @"X5O!P%@AP[4\PZX54(P^)7CC)7}$EICAR-STANDARD-ANTIVIRUS-TEST-FILE!$H+H*", "EICAR", session, out result); //I've used EICAR test string.   
        AmsiCloseSession(amsiContext, session);
        AmsiUninitialize(amsiContext);
    }
