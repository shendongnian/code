    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Win32;
    
    
    namespace MyApp.Classes
    {
        public class ExtractIconInfo
        {
            [Flags]
            private enum SHGFI : uint
            {
                SHGFI_ICON = 0x000000100,
                SHGFI_DISPLAYNAME = 0x000000200,
                SHGFI_TYPENAME = 0x000000400,
                SHGFI_ATTRIBUTES = 0x000000800,
                SHGFI_ICONLOCATION = 0x000001000,
                SHGFI_EXETYPE = 0x000002000,
                SHGFI_SYSICONINDEX = 0x000004000,
                SHGFI_LINKOVERLAY = 0x000008000,
                SHGFI_SELECTED = 0x000010000,
                SHGFI_ATTR_SPECIFIED = 0x000020000,
                SHGFI_LARGEICON = 0x000000000,
                SHGFI_SMALLICON = 0x000000001,
                SHGFI_OPENICON = 0x000000002,
                SHGFI_SHELLICONSIZE = 0x000000004,
                SHGFI_PIDL = 0x000000008,
                SHGFI_USEFILEATTRIBUTES = 0x000000010,
                SHGFI_ADDOVERLAYS = 0x000000020,
                SHGFI_OVERLAYINDEX = 0x000000040
            }
    
            [Flags]
            private enum FileAttributes : uint
            {
                Readonly = 0x00000001,
                Hidden = 0x00000002,
                System = 0x00000004,
                Directory = 0x00000010,
                Archive = 0x00000020,
                Device = 0x00000040,
                Normal = 0x00000080,
                Temporary = 0x00000100,
                SparseFile = 0x00000200,
                ReparsePoint = 0x00000400,
                Compressed = 0x00000800,
                Offline = 0x00001000,
                NotContentIndexed = 0x00002000,
                Encrypted = 0x00004000,
                Virtual = 0x00010000
            }
    
            [Flags]
            public enum ISIOI : uint
            {
                ISIOI_ICONFILE = 0x00000001,
                ISIOI_ICONINDEX = 0x00000002
            }
    
            private SortedDictionary<string, Guid> ShellIconOverlayIdentifiers;
    
            public string IconName { get; private set; }
            public Icon Icon { get; private set; }
            public int IconOverlayIndex { get; private set; }
            public Guid IconOverlayGuid { get; private set; }
    
            public ExtractIconInfo(FileInfo fi)
            {
                ExtractIcon(fi.FullName, false);
            }
            public ExtractIconInfo(DirectoryInfo di)
            {
                ExtractIcon(di.FullName, true);
            }
            public ExtractIconInfo(string path, bool isFolder)
            {
                ExtractIcon(path, isFolder);
            }
    
            [ComVisible(false)]
            [ComImport]
            [Guid("0C6C4200-C589-11D0-999A-00C04FD655E1")]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            private interface IShellIconOverlayIdentifier
            {
                [PreserveSig]
                int IsMemberOf([MarshalAs(UnmanagedType.LPWStr)] string path, uint attributes);
                [PreserveSig]
                int GetOverlayInfo([MarshalAs(UnmanagedType.LPWStr)] string iconFileBuffer, int iconFileBufferSize, out int iconIndex, out uint flags);
                [PreserveSig]
                int GetPriority(out int priority);
            }
    
            [StructLayout(LayoutKind.Sequential)]
            private struct SHFILEINFO
            {
                internal IntPtr hIcon;
                internal int iIcon;
                internal uint dwAttributes;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                internal string szDisplayName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 80)]
                internal string szTypeName;
            };
    
            [DllImport("shell32.dll")]
            private static extern IntPtr SHGetFileInfo(
                string pszPath,
                uint dwFileAttributes,
                ref SHFILEINFO psfi,
                uint cbSizeFileInfo,
                uint uFlags
            );
    
            [DllImport("shell32.dll")]
            private static extern int SHGetIconOverlayIndex(
                string pszIconPath,
                int iIconIndex
            );
    
            [DllImport("user32.dll")]
            public static extern int DestroyIcon(IntPtr hIcon);
    
            private void ExtractIcon(string path, bool isFolder)
            {
                SHFILEINFO shIconInfo = new SHFILEINFO();
                SHGetFileInfo(path, isFolder ? (uint)FileAttributes.Directory : (uint)FileAttributes.Normal, ref shIconInfo, (uint)Marshal.SizeOf(shIconInfo), (uint)SHGFI.SHGFI_ICON | (uint)SHGFI.SHGFI_LARGEICON | (uint)SHGFI.SHGFI_DISPLAYNAME | (uint)SHGFI.SHGFI_ADDOVERLAYS | (uint)SHGFI.SHGFI_OVERLAYINDEX);
                Icon = (Icon)Icon.FromHandle(shIconInfo.hIcon).Clone();
                IconName = shIconInfo.szDisplayName;
                IconOverlayIndex = (shIconInfo.iIcon >> 24) & 0xFF;
                GetOverlayIconGuid();
    
                DestroyIcon(shIconInfo.hIcon);
            }
    
            private void GetOverlayIconGuid()
            {
                IconOverlayGuid = Guid.Empty;
                GetRegistryShellIconOverlayIdentifiers();
                foreach (string key in ShellIconOverlayIdentifiers.Keys)
                {
                    string AIconFileName = string.Empty;
                    int AIconIndex = 0;
                    Guid value = ShellIconOverlayIdentifiers[key];
                    GetOverlayIconInfo(value, out AIconFileName, out AIconIndex);
                    if (SHGetIconOverlayIndex(AIconFileName, AIconIndex) == IconOverlayIndex)
                        IconOverlayGuid = value;
                }
            }
    
            private void GetOverlayIconInfo(Guid CLSID, out string path, out int index)
            {
                try
                {
                    path = new string(' ', 256);
                    uint flags = 0;
                    IShellIconOverlayIdentifier SHIOI = Activator.CreateInstance(Type.GetTypeFromCLSID(CLSID, true), true) as IShellIconOverlayIdentifier;
                    SHIOI.GetOverlayInfo(path, path.Length, out index, out flags);
                    Marshal.ReleaseComObject(SHIOI);
    
                    if ((flags & (uint)ISIOI.ISIOI_ICONFILE) != 0)
                    {
                        if ((flags & (uint)ISIOI.ISIOI_ICONINDEX) == 0) index = 0;
                    }
                    else
                    {
                        path = string.Empty;
                        index = 0;
                    }
                    path = path.Substring(0, path.IndexOf('\0'));
                }
                catch
                {
                    path = string.Empty;
                    index = 0;
                }
            }
    
            private void GetRegistryShellIconOverlayIdentifiers()
            {
                ShellIconOverlayIdentifiers = new SortedDictionary<string, Guid>();
    
                using (RegistryKey key32 = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Environment.MachineName, RegistryView.Registry32).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers"))
                    foreach (string subKey in key32.GetSubKeyNames())
                    {
                        Guid value = Guid.Parse((string)key32.OpenSubKey(subKey).GetValue(null));
                        if (!ShellIconOverlayIdentifiers.ContainsKey(subKey))
                            ShellIconOverlayIdentifiers.Add(subKey, value);
                    }
    
                using (RegistryKey key64 = RegistryKey.OpenRemoteBaseKey(RegistryHive.LocalMachine, Environment.MachineName, RegistryView.Registry64).OpenSubKey(@"SOFTWARE\Microsoft\Windows\CurrentVersion\Explorer\ShellIconOverlayIdentifiers"))
                    foreach (string subKey in key64.GetSubKeyNames())
                    {
                        Guid value = Guid.Parse((string)key64.OpenSubKey(subKey).GetValue(null));
                        if (!ShellIconOverlayIdentifiers.ContainsKey(subKey))
                            ShellIconOverlayIdentifiers.Add(subKey, value);
                    }
            }
        }
    }
