    [StructLayout(LayoutKind.Sequential)]
    public struct PIDLIST_RELATIVE
    {
        public IntPtr Ptr;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct LPITEMIDLIST
    {
        public IntPtr Ptr;
    }
    [StructLayout(LayoutKind.Sequential)]
    public struct PITEMID_CHILD
    {
        public IntPtr Ptr;
    }
    public enum STRRET_TYPE
    {
        WSTR = 0,
        OFFSET = 0x1,
        CSTR = 0x2
    };
    [StructLayout(LayoutKind.Sequential, Pack = 8, Size = 268)]
    public sealed class STRRET : IDisposable
    {
        public STRRET_TYPE uType;
        public IntPtr pOleStr;
        [DllImport("Shlwapi.dll", ExactSpelling = true, SetLastError = false)]
        private static extern int StrRetToBSTR(STRRET pstr, PITEMID_CHILD pidl, [MarshalAs(UnmanagedType.BStr)] out string pbstr);
        ~STRRET()
        {
            Dispose(false);
        }
        public override string ToString()
        {
            return ToString(default(PITEMID_CHILD));
        }
        public string ToString(PITEMID_CHILD pidl)
        {
            if (uType == STRRET_TYPE.WSTR)
            {
                if (pOleStr == IntPtr.Zero)
                {
                    return null;
                }
                string str = Marshal.PtrToStringUni(pOleStr);
                return str;
            }
            else
            {
                string str;
                int res = StrRetToBSTR(this, pidl, out str);
                if (res < 0)
                {
                    Marshal.ThrowExceptionForHR(res);
                }
                return str;
            }
        }
        #region IDisposable Support
        // This code added to correctly implement the disposable pattern.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
        private void Dispose(bool disposing)
        {
            Marshal.FreeCoTaskMem(pOleStr);
            pOleStr = IntPtr.Zero;
        }
    }
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214e6-0000-0000-c000-000000000046")]
    public interface IShellFolder
    {
        void ParseDisplayName(
            IntPtr hwnd,
            IntPtr pbc,
            [MarshalAs(UnmanagedType.LPWStr)] string pszDisplayName,
            out int pchEaten,
            out PIDLIST_RELATIVE ppidl,
            ref uint pdwAttributes);
        void EnumObjects(IntPtr hwnd, uint grfFlags, out IEnumIDList ppenumIDList);
        void BindToObject(
            PIDLIST_RELATIVE pidl,
            IntPtr pbc,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
        void BindToStorage(
            PIDLIST_RELATIVE pidl,
            IntPtr pbc,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
        [PreserveSig]
        int CompareIDs(IntPtr lParam, PIDLIST_RELATIVE pidl1, PIDLIST_RELATIVE pidl2);
        void CreateViewObject(
            IntPtr hwndOwner,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
        void GetAttributesOf(
            int cidl,
            [In, MarshalAs(UnmanagedType.LPArray)] LPITEMIDLIST[] apidl,
            ref uint rgfInOut);
        void GetUIObjectOf(
            IntPtr hwndOwner,
            int cidl,
            [In, MarshalAs(UnmanagedType.LPArray)] PITEMID_CHILD[] apidl,
            [In, MarshalAs(UnmanagedType.LPStruct)] Guid riid,
            IntPtr rgfReserved,
            [MarshalAs(UnmanagedType.IUnknown)] out object ppv);
        void GetDisplayNameOf(
            PITEMID_CHILD pidl,
            uint uFlags,
            STRRET pName);
        void SetNameOf(
            IntPtr hwnd,
            PITEMID_CHILD pidl,
            [MarshalAs(UnmanagedType.LPWStr)] string pszName,
            uint uFlags,
            out PITEMID_CHILD ppidlOut);
    }
    [ComImport]
    [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
    [Guid("000214f2-0000-0000-c000-000000000046")]
    public interface IEnumIDList
    {
        void Next(int celt, [Out, MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 2)] PITEMID_CHILD[] rgelt, out int pceltFetched);
        void Skip(int celt);
        void Reset();
        void Clone(out IEnumIDList ppenum);
    }
    // Windows >= XP
    public static class ShellFolderUtilities
    {
        [DllImport("Shell32.dll", ExactSpelling = true, SetLastError = false)]
        public static extern int SHGetSpecialFolderLocation(IntPtr hwnd, int csidl, out PIDLIST_ABSOLUTE ppidl);
        [DllImport("Shell32.dll", ExactSpelling = true, SetLastError = false)]
        public static extern int SHGetDesktopFolder(out IShellFolder ppshf);
        public static readonly int CSIDL_DESKTOP = 0x0000;
        public static readonly int CSIDL_BITBUCKET = 0x000a;
        // https://blogs.msdn.microsoft.com/oldnewthing/20110830-00/?p=9773
        public static void BindToCsidl(int csidl, Guid riid, out object ppv)
        {
            var pidl = default(PIDLIST_ABSOLUTE);
            try
            {
                int res;
                if (csidl != CSIDL_DESKTOP)
                {
                    res = SHGetSpecialFolderLocation(IntPtr.Zero, csidl, out pidl);
                    if (res < 0)
                    {
                        Marshal.ThrowExceptionForHR(res);
                    }
                }
                IShellFolder psfDesktop;
                res = SHGetDesktopFolder(out psfDesktop);
                if (res < 0)
                {
                    Marshal.ThrowExceptionForHR(res);
                }
                if (csidl == CSIDL_DESKTOP)
                {
                    ppv = psfDesktop;
                    return;
                }
                psfDesktop.BindToObject(new PIDLIST_RELATIVE { Ptr = pidl.Ptr }, IntPtr.Zero, riid, out ppv);
            }
            finally
            {
                Marshal.FreeCoTaskMem(pidl.Ptr);
            }
        }
        public static IEnumerable<PITEMID_CHILD> Enumerate(this IShellFolder sf)
        {
            IEnumIDList ppenumIDList;
            sf.EnumObjects(IntPtr.Zero, 0x00020 /* SHCONTF_FOLDERS */ | 0x00040 /* SHCONTF_NONFOLDERS */, out ppenumIDList);
            if (ppenumIDList == null)
            {
                yield break;
            }
            var items = new PITEMID_CHILD[1];
            while (true)
            {
                int fetched;
                ppenumIDList.Next(items.Length, items, out fetched);
                if (fetched == 0)
                {
                    break;
                }
                yield return items[0];
            }
        }
    }
