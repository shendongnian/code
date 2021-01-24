    [StructLayout(LayoutKind.Sequential)]
    public struct PIDLIST_ABSOLUTE
    {
        public IntPtr Ptr;
    }
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("43826d1e-e718-42ee-bc55-a1e261c37bfe")]
    public interface IShellItem
    {
        void BindToHandler(
            IntPtr pbc,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid bhid,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
        void GetParent(out IShellItem ppsi);
        void GetDisplayName(int sigdnName, out IntPtr ppszName);
        void GetAttributes(uint sfgaoMask, out uint psfgaoAttribs);
        [PreserveSig]
        int Compare(IShellItem psi, uint hint, out int piOrder);
    }
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("70629033-e363-4a28-a567-0db78006e6d7")]
    public interface IEnumShellItems
    {
        void Next(int celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] IShellItem[] rgelt, out int pceltFetched);
        void Skip(int celt);
        void Reset();
        void Clone(out IEnumShellItems ppenum);
    }
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("b63ea76d-1f85-456f-a19c-48159efa858b")]
    public interface IShellItemArray
    {
        void BindToHandler(
            IntPtr pbc,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid bhid,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [MarshalAs(UnmanagedType.IUnknown)] out object ppvOut);
        void GetPropertyStore(
            uint flags,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
        void GetPropertyDescriptionList(
            IntPtr keyType,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
        void GetAttributes(uint AttribFlags, uint sfgaoMask, out uint psfgaoAttribs);
        void GetCount(out int pdwNumItems);
        void GetItemAt(int dwIndex, out IShellItem ppsi);
        void EnumItems(out IEnumShellItems ppenumShellItems);
    }
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214e4-0000-0000-c000-000000000046")]
    public interface IContextMenu
    {
        [PreserveSig]
        int QueryContextMenu(IntPtr hMenu, uint indexMenu, int idCmdFirst, int idCmdLast, uint uFlags);
        void InvokeCommand([In] ref CMINVOKECOMMANDINFOEX pici);
        [PreserveSig]
        int GetCommandString(UIntPtr idCmd, uint uType, IntPtr pReserved, IntPtr pszName, int cchMax);
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct CMINVOKECOMMANDINFOEX
    {
        public int cbSize;
        public uint fMask;
        public IntPtr hwnd;
        // Non-unicode verbs (are there unicode verbs?)
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpVerb;
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpParameters;
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpDirectory;
        public int nShow;
        public uint dwHotKey;
        public IntPtr hIcon;
        [MarshalAs(UnmanagedType.LPStr)]
        public string lpTitle;
        // Use CMIC_MASK_UNICODE
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpVerbW;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpParametersW;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpDirectoryW;
        [MarshalAs(UnmanagedType.LPWStr)]
        public string lpTitleW;
        public int ptInvokeX;
        public int ptInvokeY;
    }
    // Windows >= Vista
    public static class ShellItemUtilities
    {
        public static readonly Guid FOLDERID_RecycleBinFolder = new Guid("b7534046-3ecb-4c18-be4e-64cd4cb7d6ac");
        public static readonly Guid BHID_EnumItems = new Guid("94f60519-2850-4924-aa5a-d15e84868039");
        public static readonly Guid BHID_SFUIObject = new Guid("3981e225-f559-11d3-8e3a-00c04f6837d5");
        // From Windows 7
        [DllImport("Shell32.dll", ExactSpelling = true, SetLastError = false)]
        public static extern int SHGetKnownFolderItem(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
            uint dwFlags,
            IntPtr hToken,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            out IShellItem ppv);
        // For Windows Vista
        [DllImport("Shell32.dll", ExactSpelling = true, SetLastError = false)]
        public static extern int SHCreateItemFromIDList(PIDLIST_ABSOLUTE pidl, [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid, out IShellItem ppv);
        // For Windows Vista
        [DllImport("Shell32.dll", ExactSpelling = true, SetLastError = false)]
        public static extern int SHGetKnownFolderIDList(
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid rfid,
            uint dwFlags,
            IntPtr hToken,
            out PIDLIST_ABSOLUTE ppidl);
        // From Windows Vista
        [DllImport("Shell32.dll", ExactSpelling = true, SetLastError = false)]
        public static extern int SHGetIDListFromObject([MarshalAs(UnmanagedType.Interface)] object punk, out PIDLIST_ABSOLUTE ppidl);
        [DllImport("Shell32.dll", ExactSpelling = true, SetLastError = false)]
        public static extern int SHCreateShellItemArrayFromIDLists(int cidl, [In] PIDLIST_ABSOLUTE[] rgpidl, out IShellItemArray ppsiItemArray);
        public static IEnumerable<IShellItem> Enumerate(this IShellItem si)
        {
            object pesiTemp;
            si.BindToHandler(IntPtr.Zero, BHID_EnumItems, typeof(IEnumShellItems).GUID, out pesiTemp);
            var pesi = (IEnumShellItems)pesiTemp;
            var items = new IShellItem[10];
            while (true)
            {
                int fetched;
                pesi.Next(1, items, out fetched);
                if (fetched == 0)
                {
                    break;
                }
                yield return items[0];
            }
        }
    }
    public static class ContextMenuUtilities
    {
        [DllImport("User32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern IntPtr CreateMenu();
        [DllImport("User32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern bool DestroyMenu(IntPtr hMenu);
        [DllImport("User32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern int GetMenuItemCount(IntPtr hMenu);
        [DllImport("User32.dll", ExactSpelling = true, SetLastError = true)]
        public static extern uint GetMenuItemID(IntPtr hMenu, int nPos);
        [DllImport("User32.dll", CharSet = CharSet.Unicode, EntryPoint = "GetMenuStringW", ExactSpelling = true, SetLastError = true)]
        public static extern int GetMenuString(IntPtr hMenu, uint uIDItem, [Out] StringBuilder lpString, int nMaxCount, uint uFlag);
        public static string[] GetVerbs(IContextMenu cm, bool ansi = true)
        {
            IntPtr menu = IntPtr.Zero;
            try
            {
                menu = CreateMenu();
                // It isn't clear why short.MaxValue, but 0x7FFF is very used around the .NET!
                int res = cm.QueryContextMenu(menu, 0, 0, short.MaxValue, 0);
                if (res < 0)
                {
                    Marshal.ThrowExceptionForHR(res);
                }
                //var sb = new StringBuilder(128);
                int count = GetMenuItemCount(menu);
                var verbs = new List<string>(count);
                var handle = default(GCHandle);
                try
                {
                    var bytes = new byte[ansi ? 128 : 256];
                    handle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                    IntPtr ptr = handle.AddrOfPinnedObject();
                    for (int i = 0; i < count; i++)
                    {
                        uint id = GetMenuItemID(menu, i);
                        if (id == uint.MaxValue)
                        {
                            continue;
                        }
                        //GetMenuString(menu, (uint)i, sb, sb.Capacity, 0x00000400 /* MF_BYPOSITION */);
                        //string description = sb.ToString();
                        //sb.Clear();
                        res = cm.GetCommandString((UIntPtr)id, ansi ? (uint)0x00000002 /* GCS_VALIDATEA */ : 0x00000006 /* GCS_VALIDATEW */, IntPtr.Zero, ptr, bytes.Length);
                        if (res < 0)
                        {
                            continue;
                        }
                        if (res == 0)
                        {
                            res = cm.GetCommandString((UIntPtr)id, ansi ? (uint)0x00000000 /* GCS_VERBA */ : 0x00000004 /* GCS_VERBW */, IntPtr.Zero, ptr, bytes.Length);
                            if (res < 0)
                            {
                                Marshal.ThrowExceptionForHR(res);
                            }
                            verbs.Add(ansi ? Marshal.PtrToStringAnsi(ptr) : Marshal.PtrToStringUni(ptr));
                        }
                    }
                }
                finally
                {
                    if (handle.IsAllocated)
                    {
                        handle.Free();
                    }
                }
                return verbs.ToArray();
            }
            finally
            {
                if (menu != IntPtr.Zero)
                {
                    DestroyMenu(menu);
                }
            }
        }
    }
