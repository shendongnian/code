    RemoveProperties("myfile.doc", SummaryInformationFormatId, PIDSI_AUTHOR, PIDSI_REVNUMBER, PIDSI_LASTAUTHOR);
    ...
    public static void RemoveProperties(string filePath, Guid propertySet, params int[] ids)
    {
        if (filePath == null)
            throw new ArgumentNullException(nameof(filePath));
        if (ids == null || ids.Length == 0)
            return;
        int hr = StgOpenStorageEx(filePath, STGM.STGM_DIRECT_SWMR | STGM.STGM_READWRITE | STGM.STGM_SHARE_DENY_WRITE, STGFMT.STGFMT_ANY, 0, IntPtr.Zero, IntPtr.Zero, typeof(IPropertySetStorage).GUID, out IPropertySetStorage setStorage);
        if (hr != 0)
            throw new Win32Exception(hr);
        try
        {
            hr = setStorage.Open(propertySet, STGM.STGM_READWRITE | STGM.STGM_SHARE_EXCLUSIVE, out IPropertyStorage storage);
            if (hr != 0)
            {
                const int STG_E_FILENOTFOUND = unchecked((int)0x80030002);
                if (hr == STG_E_FILENOTFOUND)
                    return;
                throw new Win32Exception(hr);
            }
            var props = new List<PROPSPEC>();
            foreach (int id in ids)
            {
                var prop = new PROPSPEC();
                prop.ulKind = PRSPEC.PRSPEC_PROPID;
                prop.union.propid = id;
                props.Add(prop);
            }
            storage.DeleteMultiple(props.Count, props.ToArray());
            storage.Commit(0);
        }
        finally
        {
            Marshal.ReleaseComObject(setStorage);
        }
    }
    // "The Summary Information Property Set"
    // https://msdn.microsoft.com/en-us/library/windows/desktop/aa380376.aspx
    public static readonly Guid SummaryInformationFormatId = new Guid("F29F85E0-4FF9-1068-AB91-08002B27B3D9");
    public const int PIDSI_AUTHOR = 4;
    public const int PIDSI_LASTAUTHOR = 8;
    public const int PIDSI_REVNUMBER = 9;
    [Flags]
    private enum STGM
    {
        STGM_READ = 0x00000000,
        STGM_READWRITE = 0x00000002,
        STGM_SHARE_DENY_NONE = 0x00000040,
        STGM_SHARE_DENY_WRITE = 0x00000020,
        STGM_SHARE_EXCLUSIVE = 0x00000010,
        STGM_DIRECT_SWMR = 0x00400000
    }
    private enum STGFMT
    {
        STGFMT_STORAGE = 0,
        STGFMT_FILE = 3,
        STGFMT_ANY = 4,
        STGFMT_DOCFILE = 5
    }
    [StructLayout(LayoutKind.Sequential)]
    private struct PROPSPEC
    {
        public PRSPEC ulKind;
        public PROPSPECunion union;
    }
    [StructLayout(LayoutKind.Explicit)]
    private struct PROPSPECunion
    {
        [FieldOffset(0)]
        public int propid;
        [FieldOffset(0)]
        public IntPtr lpwstr;
    }
    private enum PRSPEC
    {
        PRSPEC_LPWSTR = 0,
        PRSPEC_PROPID = 1
    }
    [DllImport("ole32.dll")]
    private static extern int StgOpenStorageEx([MarshalAs(UnmanagedType.LPWStr)] string pwcsName, STGM grfMode, STGFMT stgfmt, int grfAttrs, IntPtr pStgOptions, IntPtr reserved2, [MarshalAs(UnmanagedType.LPStruct)] Guid riid, out IPropertySetStorage ppObjectOpen);
    [Guid("0000013A-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    private interface IPropertySetStorage
    {
        void Unused1();
        [PreserveSig]
        int Open([MarshalAs(UnmanagedType.LPStruct)] Guid rfmtid, STGM grfMode, out IPropertyStorage storage);
    }
    [Guid("00000138-0000-0000-C000-000000000046"), InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIUnknown)]
    private interface IPropertyStorage
    {
        void Unused1();
        void Unused2();
        void DeleteMultiple(int cpspec, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 0)] PROPSPEC[] rgpspec);
        void Unused4();
        void Unused5();
        void Unused6();
        void Commit(uint grfCommitFlags);
        // rest ommited
    }
