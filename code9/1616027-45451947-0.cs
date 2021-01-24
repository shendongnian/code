    [DllImport("API-MS-WIN-CORE-WINRT-L1-1-0.DLL")]
    private static extern int/* HRESULT */ RoGetActivationFactory([MarshalAs(UnmanagedType.HString)]string typeName, [MarshalAs(UnmanagedType.LPStruct)] Guid factoryIID, out IntPtr factory);
    static bool IsWindows10()
    {
        IntPtr factory;
        var IID_IActivationFactory = new Guid(0x00000035, 0x0000, 0x0000, 0xC0, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x46);
        var hr = RoGetActivationFactory("Windows.ApplicationModel.ExtendedExecution.ExtendedExecutionSession", IID_IActivationFactory, out factory);
        if (hr < 0)
            return false;
        Marshal.Release(factory);
        return true;
    }
