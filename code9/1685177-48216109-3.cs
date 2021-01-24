    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    
    [DllImport("kernel32.dll", EntryPoint = "FindFirstChangeNotification")]
    static extern System.IntPtr FindFirstChangeNotification(string lpPathName, bool bWatchSubtree, uint dwNotifyFilter);
    
    [DllImport("kernel32.dll", EntryPoint = "FindNextChangeNotification")]
    static extern bool FindNextChangeNotification(System.IntPtr hChangedHandle);
    
    [DllImport("kernel32.dll", EntryPoint = "FindCloseChangeNotification")]
    static extern bool FindCloseChangeNotification(System.IntPtr hChangedHandle);
    
    [DllImport("kernel32.dll", EntryPoint = "WaitForSingleObject")]
    static extern uint WaitForSingleObject(System.IntPtr handle, uint dwMilliseconds);
    
    [DllImport("kernel32.dll", EntryPoint = "ReadDirectoryChangesW")]
    static extern bool ReadDirectoryChangesW(System.IntPtr hDirectory, System.IntPtr lpBuffer, uint nBufferLength, bool bWatchSubtree, uint dwNotifyFilter, out uint lpBytesReturned, System.IntPtr lpOverlapped, IntPtr lpCompletionRoutine);
    
    [DllImport("kernel32.dll", EntryPoint = "CreateFile")]
    public static extern IntPtr CreateFile(string lpFileName, uint dwDesiredAccess, uint dwShareMode, IntPtr SecurityAttributes, uint dwCreationDisposition, uint dwFlagsAndAttributes, IntPtr hTemplateFile);
    
    enum FileSystemNotifications
    {
        FileNameChanged = 0x00000001,
        DirectoryNameChanged = 0x00000002,
        FileAttributesChanged = 0x00000004,
        FileSizeChanged = 0x00000008,
        FileModified = 0x00000010,
        FileSecurityChanged = 0x00000100,
    }
    
    enum FileActions
    {
        FileAdded = 0x00000001,
        FileRemoved = 0x00000002,
        FileModified = 0x00000003,
        FileRenamedOld = 0x00000004,
        FileRenamedNew = 0x00000005
    }
    
    enum FileEventType
    {
        FileAdded,
        FileChanged,
        FileDeleted,
        FileRenamed
    }
    
    class FileEvent
    {
        private readonly FileEventType eventType;
        private readonly FileInfo file;
    
        public FileEvent(string fileName, FileEventType eventType)
        {
            this.file = new FileInfo(fileName);
            this.eventType = eventType;
        }
    
        public FileEventType EventType => eventType;
        public FileInfo File => file;
    }
    
    [StructLayout(LayoutKind.Sequential)]
    struct FileNotifyInformation
    {
        public int NextEntryOffset;
        public int Action;
        public int FileNameLength;
        public IntPtr FileName;
    }
    
    class DirectoryWatcher
    {
        private const int MaxChanges = 4096;
        private readonly DirectoryInfo directory;
    
        public DirectoryWatcher(string dirPath)
        {
            this.directory = new DirectoryInfo(dirPath);
        }
    
        public IEnumerable<FileEvent> Watch(bool watchSubFolders = false)
        {
            var directoryHandle = CreateFile(directory.FullName, 0x80000000, 0x00000007, IntPtr.Zero, 3, 0x02000000, IntPtr.Zero);    
            var fileCreatedDeletedOrUpdated = FileSystemNotifications.FileNameChanged | FileSystemNotifications.FileModified;
            var waitable = FindFirstChangeNotification(directory.FullName, watchSubFolders, (uint)fileCreatedDeletedOrUpdated);
            var notifySize = Marshal.SizeOf(typeof(FileNotifyInformation));
    
            do
            {
                WaitForSingleObject(waitable, 0xFFFFFFFF); // Infinite wait
                var changes = new FileNotifyInformation[MaxChanges];
                var pinnedArray = GCHandle.Alloc(changes, GCHandleType.Pinned);
                var buffer = pinnedArray.AddrOfPinnedObject();
                uint bytesReturned;            
    
                ReadDirectoryChangesW(directoryHandle, buffer, (uint)(notifySize * MaxChanges), watchSubFolders, (uint)fileCreatedDeletedOrUpdated, out bytesReturned, IntPtr.Zero, IntPtr.Zero);
    
                for (var i = 0; i < bytesReturned / notifySize; i += 1)
                {
                    var change = Marshal.PtrToStructure<FileNotifyInformation>(new IntPtr(buffer.ToInt64() + i * notifySize));
    
                    if ((change.Action & (int)FileActions.FileAdded) == (int)FileActions.FileAdded)
                    {
                        yield return new FileEvent(Marshal.PtrToStringAuto(change.FileName, change.FileNameLength), FileEventType.FileAdded);
                    }
                    else if ((change.Action & (int)FileActions.FileModified) == (int)FileActions.FileModified)
                    {
                        yield return new FileEvent(Marshal.PtrToStringAuto(change.FileName, change.FileNameLength), FileEventType.FileChanged);
                    }
                    else if ((change.Action & (int)FileActions.FileRemoved) == (int)FileActions.FileRemoved)
                    {
                        yield return new FileEvent(Marshal.PtrToStringAuto(change.FileName, change.FileNameLength), FileEventType.FileDeleted);
                    }
                    else if ((change.Action & (int)FileActions.FileRenamedNew) == (int)FileActions.FileRenamedNew)
                    {
                        yield return new FileEvent(Marshal.PtrToStringAuto(change.FileName, change.FileNameLength), FileEventType.FileRenamed);
                    }
                }
    
                pinnedArray.Free();
            } while (FindNextChangeNotification(waitable));
    
            FindCloseChangeNotification(waitable);
        }
    }
    
    var watcher = new DirectoryWatcher(@"C:\Temp");
    
    foreach (var change in watcher.Watch())
    {
        Console.WriteLine("File {0} was {1}", change.File.Name, change.EventType);
    }
