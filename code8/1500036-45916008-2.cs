    using System;
    using System.Drawing;
    using System.IO;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace MyApp.Classes
    {
        public class ExtractIconInfo
        {
            private const uint FILE_ATTRIBUTE_NORMAL = 0x80;
            private const uint FILE_ATTRIBUTE_DIRECTORY = 0x10;
            private const uint SHGFI_ICON = 0x100;
            private const uint SHGFI_LARGEICON = 0x0;
            private const uint SHGFI_ADDOVERLAYS = 0x000000020;
            private const uint SHGFI_OVERLAYINDEX = 0x000000040;
    
            public string IconName { get; private set; }
            public Icon Icon { get; private set; }
            public string IconHash { get { return GetHash(Icon); } }
            public Icon IconWithOverlay { get; private set; }
            public string IconWithOverlayHash { get { return GetHash(IconWithOverlay); } }
            public int OverlayIndex { get; private set; }
    
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
    
            public void ExtractIcon(string path, bool isFolder)
            {
                SHFILEINFO shIconInfo = new SHFILEINFO();
                SHGetFileInfo(path, isFolder ? FILE_ATTRIBUTE_DIRECTORY : FILE_ATTRIBUTE_NORMAL, ref shIconInfo, (uint)Marshal.SizeOf(shIconInfo), SHGFI_ICON | SHGFI_LARGEICON);
                Icon = Icon.FromHandle(shIconInfo.hIcon);
                IconName = shIconInfo.szDisplayName;
                if (string.IsNullOrWhiteSpace(IconName)) IconName = Path.GetFileNameWithoutExtension(path);
                if (string.IsNullOrWhiteSpace(IconName)) IconName = Path.GetDirectoryName(path);
                if (string.IsNullOrWhiteSpace(IconName)) IconName = Path.GetPathRoot(path);
                if (string.IsNullOrWhiteSpace(IconName)) IconName = Path.GetRandomFileName();
    
                SHFILEINFO shIconWOverlayInfo = new SHFILEINFO();
                SHGetFileInfo(path, isFolder ? FILE_ATTRIBUTE_DIRECTORY : FILE_ATTRIBUTE_NORMAL, ref shIconWOverlayInfo, (uint)Marshal.SizeOf(shIconWOverlayInfo), SHGFI_ICON | SHGFI_ADDOVERLAYS);
                IconWithOverlay = Icon.FromHandle(shIconWOverlayInfo.hIcon);
                OverlayIndex = shIconWOverlayInfo.iIcon;
            }
    
            private string GetHash(Icon icon)
            {
                ImageConverter ic = new ImageConverter();
                byte[] imgBytes = (byte[])ic.ConvertTo(icon.ToBitmap(), typeof(byte[]));
                byte[] imgHash = MD5.Create().ComputeHash(imgBytes);
                return Encoding.Default.GetString(imgHash);
            }
        }
    }
