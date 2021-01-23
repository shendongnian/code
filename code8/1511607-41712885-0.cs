    public static object CreateLocalServer(Guid clsid)
    {
        return CoCreateInstance(clsid, null, CLSCTX.LOCAL_SERVER, IID_IUnknown);
    }
    public static object CreateLocalServer(string progid)
    {
        Contract.Requires(!string.IsNullOrEmpty(progid));
        Guid clsid;
        CLSIDFromProgID(progid, out clsid);
        return CreateLocalServer(clsid);
    }
    enum CLSCTX : uint
    {
        INPROC_SERVER = 0x1,
        INPROC_HANDLER = 0x2,
        LOCAL_SERVER = 0x4,
        INPROC_SERVER16 = 0x8,
        REMOTE_SERVER = 0x10,
        INPROC_HANDLER16 = 0x20,
        RESERVED1 = 0x40,
        RESERVED2 = 0x80,
        RESERVED3 = 0x100,
        RESERVED4 = 0x200,
        NO_CODE_DOWNLOAD = 0x400,
        RESERVED5 = 0x800,
        NO_CUSTOM_MARSHAL = 0x1000,
        ENABLE_CODE_DOWNLOAD = 0x2000,
        NO_FAILURE_LOG = 0x4000,
        DISABLE_AAA = 0x8000,
        ENABLE_AAA = 0x10000,
        FROM_DEFAULT_CONTEXT = 0x20000,
        ACTIVATE_32_BIT_SERVER = 0x40000,
        ACTIVATE_64_BIT_SERVER = 0x80000
    }
    [DllImport(Ole32, ExactSpelling = true, PreserveSig = false)]
    [return: MarshalAs(UnmanagedType.Interface)]
    public static extern object CoCreateInstance(
       [In, MarshalAs(UnmanagedType.LPStruct)] Guid rclsid,
       [MarshalAs(UnmanagedType.IUnknown)] object pUnkOuter,
       CLSCTX dwClsContext,
       [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid);
    [DllImport(Ole32, CharSet = CharSet.Unicode, PreserveSig = false)]
    public static extern void CLSIDFromProgID(string progId, out Guid rclsid);
