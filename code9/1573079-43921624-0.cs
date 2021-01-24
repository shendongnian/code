    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("BD39D1D2-BA2F-486A-89B0-B4B0CB466891")]
    private interface ICLRRuntimeInfo
    {
        void XGetVersionString();
        void XGetRuntimeDirectory();
        void XIsLoaded();
        void XIsLoadable();
        void XLoadErrorString();
        void XLoadLibrary();
        void XGetProcAddress();
        void XGetInterface();
        void XSetDefaultStartupFlags();
        void XGetDefaultStartupFlags();
    [MethodImpl(MethodImplOptions.InternalCall, MethodCodeType = MethodCodeType.Runtime)]
        void BindAsLegacyV2Runtime();
    }
    public Startup(IHostingEnvironment env)
    {
        ICLRRuntimeInfo clrRuntimeInfo = 
            (ICLRRuntimeInfo)RuntimeEnvironment.GetRuntimeInterfaceAsObject(
            Guid.Empty,
            typeof(ICLRRuntimeInfo).GUID);
        var builder = new ConfigurationBuilder()
            .SetBasePath(env.ContentRootPath)
            .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
            .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
            .AddEnvironmentVariables();
    
    clrRuntimeInfo.BindAsLegacyV2Runtime();
