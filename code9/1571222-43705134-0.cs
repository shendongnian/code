    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Runtime.InteropServices;
    using System.IO;
    namespace ConsoleApplication1
    {
        class Program
        {
            static void Main(string[] args)
            {
                File_Handle handle = new File_Handle();
                handle.Get_Index();
                handle.Retrieve_File();
            }
        }
        public class WinAPI
        {
            [DllImport("ntdll.dll", SetLastError = true)]
            public static extern IntPtr NtQueryInformationFile(IntPtr fileHandle, ref IO_STATUS_BLOCK IoStatusBlock, IntPtr pInfoBlock, uint length, FILE_INFORMATION_CLASS fileInformation);
            public struct IO_STATUS_BLOCK
            {
                uint status;
                ulong information;
            }
            public struct _FILE_INTERNAL_INFORMATION
            {
                public ulong IndexNumber;
            }
            // Abbreviated, there are more values than shown
            public enum FILE_INFORMATION_CLASS
            {
                FileDirectoryInformation = 1,     // 1
                FileFullDirectoryInformation,     // 2
                FileBothDirectoryInformation,     // 3
                FileBasicInformation,         // 4
                FileStandardInformation,      // 5
                FileInternalInformation      // 6
            }
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern bool GetFileInformationByHandle(IntPtr hFile, out BY_HANDLE_FILE_INFORMATION lpFileInformation);
            [DllImport("kernel32.dll", SetLastError = true)]
            public static extern IntPtr OpenFileById(IntPtr hFile, FILE_ID_DESCRIPTOR lpFileID, uint dwDesiredAccess, uint dwShareMode, uint dwFlagas);
            [DllImport("kernel32.dll", BestFitMapping = false, ThrowOnUnmappableChar = true)]
            public static extern int OpenFile([System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.LPStr)]string lpFileName, out OFSTRUCT lpReOpenBuff,
               OpenFileStyle uStyle);
            [StructLayout(LayoutKind.Explicit)]
            public struct FILE_ID_DESCRIPTOR
            {
                [FieldOffset(0)]
                public uint dwSize;
                [FieldOffset(4)]
                public FILE_ID_TYPE type;
                // [FieldOffset(8)] public Guid guid;
                [FieldOffset(8)]
                public long FileReferenceNumber;
            }
            public enum FILE_ID_TYPE
            {
                FileIdType = 0,
                ObjectIdType = 1,
                ExtendedFileIdType = 2,
                MaximumFileIdType
            };
            public struct BY_HANDLE_FILE_INFORMATION
            {
                public uint FileAttributes;
                public FILETIME CreationTime;
                public FILETIME LastAccessTime;
                public FILETIME LastWriteTime;
                public uint VolumeSerialNumber;
                public uint FileSizeHigh;
                public uint FileSizeLow;
                public uint NumberOfLinks;
                public uint FileIndexHigh;
                public uint FileIndexLow;
            }
            [System.Runtime.InteropServices.StructLayout(LayoutKind.Sequential)]
            public struct OFSTRUCT
            {
                public byte cBytes;
                public byte fFixedDisc;
                public UInt16 nErrCode;
                public UInt16 Reserved1;
                public UInt16 Reserved2;
                [System.Runtime.InteropServices.MarshalAs(System.Runtime.InteropServices.UnmanagedType.ByValTStr, SizeConst = 128)]
                public string szPathName;
            }
            [Flags]
            public enum OpenFileStyle : uint
            {
                OF_CANCEL = 0x00000800,  // Ignored. For a dialog box with a Cancel button, use OF_PROMPT.
                OF_CREATE = 0x00001000,  // Creates a new file. If file exists, it is truncated to zero (0) length.
                OF_DELETE = 0x00000200,  // Deletes a file.
                OF_EXIST = 0x00004000,  // Opens a file and then closes it. Used to test that a file exists
                OF_PARSE = 0x00000100,  // Fills the OFSTRUCT structure, but does not do anything else.
                OF_PROMPT = 0x00002000,  // Displays a dialog box if a requested file does not exist 
                OF_READ = 0x00000000,  // Opens a file for reading only.
                OF_READWRITE = 0x00000002,  // Opens a file with read/write permissions.
                OF_REOPEN = 0x00008000,  // Opens a file by using information in the reopen buffer.
                // For MS-DOS–based file systems, opens a file with compatibility mode, allows any process on a 
                // specified computer to open the file any number of times.
                // Other efforts to open a file with other sharing modes fail. This flag is mapped to the 
                // FILE_SHARE_READ|FILE_SHARE_WRITE flags of the CreateFile function.
                OF_SHARE_COMPAT = 0x00000000,
                // Opens a file without denying read or write access to other processes.
                // On MS-DOS-based file systems, if the file has been opened in compatibility mode
                // by any other process, the function fails.
                // This flag is mapped to the FILE_SHARE_READ|FILE_SHARE_WRITE flags of the CreateFile function.
                OF_SHARE_DENY_NONE = 0x00000040,
                // Opens a file and denies read access to other processes.
                // On MS-DOS-based file systems, if the file has been opened in compatibility mode,
                // or for read access by any other process, the function fails.
                // This flag is mapped to the FILE_SHARE_WRITE flag of the CreateFile function.
                OF_SHARE_DENY_READ = 0x00000030,
                // Opens a file and denies write access to other processes.
                // On MS-DOS-based file systems, if a file has been opened in compatibility mode,
                // or for write access by any other process, the function fails.
                // This flag is mapped to the FILE_SHARE_READ flag of the CreateFile function.
                OF_SHARE_DENY_WRITE = 0x00000020,
                // Opens a file with exclusive mode, and denies both read/write access to other processes.
                // If a file has been opened in any other mode for read/write access, even by the current process,
                // the function fails.
                OF_SHARE_EXCLUSIVE = 0x00000010,
                // Verifies that the date and time of a file are the same as when it was opened previously.
                // This is useful as an extra check for read-only files.
                OF_VERIFY = 0x00000400,
                // Opens a file for write access only.
                OF_WRITE = 0x00000001
            }
        }
        public class File_Handle
        {
            public ulong Get_Index()
            {
                WinAPI.BY_HANDLE_FILE_INFORMATION objectFileInfo = new WinAPI.BY_HANDLE_FILE_INFORMATION();
                FileInfo fi = new FileInfo(@"c:\Temp\Test.txt");
                FileStream fs = fi.Open(FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                WinAPI.GetFileInformationByHandle(fs.Handle, out objectFileInfo);
                fs.Close();
                ulong fileIndex = ((ulong)objectFileInfo.FileIndexHigh << 32) + (ulong)objectFileInfo.FileIndexLow;
                return fileIndex;
            }
            public string Retrieve_File()
            {
                WinAPI.OFSTRUCT ofStruct = new WinAPI.OFSTRUCT();
                int err = WinAPI.OpenFile(@"c:\Temp\Test.txt", out ofStruct, WinAPI.OpenFileStyle.OF_READ);
                return "Dummy";
            }
        }
    }
