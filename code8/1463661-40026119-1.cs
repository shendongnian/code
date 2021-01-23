    [DllImport("api.dll")]
    extern public static int CppFunction(
        ref byte pbAdapter, 
        ref byte pbTargetID, 
        string pcVendor, 
        string pcProduct, 
        string pcRelease,
        int iMessageBox);
