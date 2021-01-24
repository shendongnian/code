    // This code snippet is provided under the Microsoft Permissive License.
    using System;
    using System.IO;
    using System.Runtime.InteropServices;
    using Microsoft.Win32.SafeHandles;
    
    [DllImport("kernel32.dll", SetLastError = true, CharSet = CharSet.Unicode)]
    internal static extern SafeFileHandle CreateFile(
        string lpFileName,
        EFileAccess dwDesiredAccess,
        EFileShare dwShareMode,
        IntPtr lpSecurityAttributes,
        ECreationDisposition dwCreationDisposition,
        EFileAttributes dwFlagsAndAttributes,
        IntPtr hTemplateFile);
    
    public static void TestCreateAndWrite(string fileName) {
    
        string formattedName = @"\\?\" + fileName;
        // Create a file with generic write access
        SafeFileHandle fileHandle = CreateFile(formattedName,
            EFileAccess.GenericWrite, EFileShare.None, IntPtr.Zero,
            ECreationDisposition.CreateAlways, 0, IntPtr.Zero);
    
        // Check for errors
        int lastWin32Error = Marshal.GetLastWin32Error();
        if (fileHandle.IsInvalid) {
            throw new System.ComponentModel.Win32Exception(lastWin32Error);
        }
    
        // Pass the file handle to FileStream. FileStream will close the
        // handle
        using (FileStream fs = new FileStream(fileHandle,
                                        FileAccess.Write)) {
            fs.WriteByte(80);
            fs.WriteByte(81);
            fs.WriteByte(83);
            fs.WriteByte(84);
        }
    }
