    using System.Collections.Generic;
    using System.IO;
    List<FileInfo> files = new List<FileInfo>();
    DirectoryInfo rootDir = new DirectoryInfo("");
    var directories = rootDir.GetDirectories("20160314*");
    foreach (var directory in directories)
    {
        files.AddRange(directory.GetFiles());
    }
    IEnumerable<string> fileNames = files.Select(f => f.Name);
