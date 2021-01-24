    using System;
    using System.Collections.Generic;
    //
    using System.Runtime.InteropServices;
    using System.IO;
    //
    namespace TestFileDelete
    {
        class FileDelete
        {
            [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
            struct WIN32_FIND_DATAW
            {
                public FileAttributes dwFileAttributes;
                public System.Runtime.InteropServices.ComTypes.FILETIME ftCreationTime;
                public System.Runtime.InteropServices.ComTypes.FILETIME ftLastAccessTime;
                public System.Runtime.InteropServices.ComTypes.FILETIME ftLastWriteTime;
                public UInt32 nFileSizeHigh;  //  DWORD
                public UInt32 nFileSizeLow;  //  DWORD
                public UInt32 dwReserved0;    //  DWORD
                public UInt32 dwReserved1;  //  DWORD
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 260)]
                public String cFileName;
                [MarshalAs(UnmanagedType.ByValTStr, SizeConst = 14)]
                public String cAlternateFileName;
            };
        
            static readonly IntPtr INVALID_HANDLE_VALUE = new IntPtr(-1);
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern IntPtr FindFirstFileW(String lpFileName, out WIN32_FIND_DATAW lpFindFileData);
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern Boolean FindNextFileW(IntPtr hFindFile, out WIN32_FIND_DATAW lpFindFileData);
            [DllImport("kernel32.dll")]
            private static extern Boolean FindClose(IntPtr handle);
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            public static extern Boolean DeleteFileW(String lpFileName);    //  Deletes an existing file
            [DllImport("kernel32.dll", CharSet = CharSet.Unicode, SetLastError = true)]
            private static extern Boolean RemoveDirectoryW(String lpPathName);   //  Deletes an existing empty directory
      
            //  This method check to see if the given folder is empty or not.
            public static Boolean IsEmptyFolder(String folder)
            {
                Boolean res = true;
                if (folder == null && folder.Length == 0)
                {
                    throw new Exception(folder + "is invalid");
                }
                WIN32_FIND_DATAW findFileData;
                String searchFiles = folder + @"\*.*";
                IntPtr searchHandle = FindFirstFileW(searchFiles, out findFileData);
                if (searchHandle == INVALID_HANDLE_VALUE)
                {
                    throw new Exception("Cannot check folder " + folder);
                }
                do
                {
                    if ((findFileData.dwFileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                    {
                        //  found a sub folder
                        if (findFileData.cFileName != "." && findFileData.cFileName != "..")
                        {
                            res = false;
                            break;
                        }
                    }   //  if ((findFileData.dwFileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                    else
                    {
                        //  found a file
                        res = false;
                        break;
                    }
                } while (FindNextFileW(searchHandle, out findFileData));
                FindClose(searchHandle);
                return res;
            }   //  public static Boolean IsEmptyFolder(String folder)
            //  This method deletes the given folder
            public static Boolean DeleteFolder(String folder)
            {
                Boolean res = true;
                //  keep non-empty folders to delete later (after we delete everything inside)
                Stack<String> nonEmptyFolder = new Stack<String>();
                String currentFolder = folder;
                do
                {
                    Boolean isEmpty = false;
                    try
                    {
                        isEmpty = IsEmptyFolder(currentFolder);
                    }
                    catch (Exception ex)
                    {
                        //  Something wrong
                        res = false;
                        break;
                    }
                    if (!isEmpty)
                    {
                        nonEmptyFolder.Push(currentFolder);
                        WIN32_FIND_DATAW findFileData;
                        IntPtr searchHandle = FindFirstFileW(currentFolder + @"\*.*", out findFileData);
                        if (searchHandle != INVALID_HANDLE_VALUE)
                        {
                            do
                            {   //  for each folder, find all of its sub folders and files
                                String foundPath = currentFolder + @"\" + findFileData.cFileName;
                                if ((findFileData.dwFileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                                {
                                    //  found a sub folder
                                    if (findFileData.cFileName != "." && findFileData.cFileName != "..")
                                    {
                                        if (IsEmptyFolder(foundPath))
                                        {   //  found an empty folder, delete it
                                            if (!(res = RemoveDirectoryW(foundPath)))
                                            {
                                                Int32 error = Marshal.GetLastWin32Error();
                                                break;
                                            }
                                        }
                                        else
                                        {   //  found a non-empty folder
                                            nonEmptyFolder.Push(foundPath);
                                        }
                                    }   //  if (findFileData.cFileName != "." && findFileData.cFileName != "..")
                                }   //  if ((findFileData.dwFileAttributes & FileAttributes.Directory) == FileAttributes.Directory)
                                else
                                {
                                    //  found a file, delete it
                                    if (!(res = DeleteFileW(foundPath)))
                                    {
                                        Int32 error = Marshal.GetLastWin32Error();
                                        break;
                                    }
                                }
                            } while (FindNextFileW(searchHandle, out findFileData));
                            FindClose(searchHandle);
                        }   //  if (searchHandle != INVALID_HANDLE_VALUE)
                    }//  if (!IsEmptyFolder(folder))
                    else
                    {
                        if (!(res = RemoveDirectoryW(currentFolder)))
                        {
                            Int32 error = Marshal.GetLastWin32Error();
                            break;
                        }
                    }
                    if (nonEmptyFolder.Count > 0)
                    {
                        currentFolder = nonEmptyFolder.Pop();
                    }
                    else
                    {
                        currentFolder = null;
                    }
                } while (currentFolder != null && res);
                return res;
            }   //  public static Boolean DeleteFolder(String folder)
        };
        class Program
        {
            static void Main(string[] args)
            {
                DateTime t1 = DateTime.Now;
                try
                {
                    Boolean b = FileDelete.DeleteFolder(@"d:\test1");
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                DateTime t2 = DateTime.Now;
                TimeSpan ts = t2 - t1;
                Console.WriteLine(ts.Seconds);
            } 
        } 
    }
