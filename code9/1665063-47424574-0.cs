    using System.Security.AccessControl;
    using Alphaleonis.Win32.Filesystem;
    using Alphaleonis.Win32.Security;
    ...
    ...
    
    var sourceFile = @"c:\temp\a.txt";
    var destinationFile = @"c:\temp\b.txt";
    
    var buffer = new byte[4096];
    
    using (var privilegeEnabler = new PrivilegeEnabler(Privilege.Backup, Privilege.Restore))
    {
        using (var readStream = new BackupFileStream(sourceFile,
                     System.IO.FileMode.Open, FileSystemRights.Read))
        using (var writeStream = new BackupFileStream(destinationFile,
                     System.IO.FileMode.Create, FileSystemRights.FullControl))
        {
            int count;
    
            while ((count = readStream.Read(buffer, 0, buffer.Length, true)) > 0)
            {
                writeStream.Write(buffer, 0, count, true);
            }
        }
    }
