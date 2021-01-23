    List<string> result = new List<string>();
    foreach (System.IO.DriveInfo driveInfo in System.IO.DriveInfo.GetDrives())
    {
        result.AddRange(System.IO.Directory.GetFiles(driveInfo.Name, "*.exe", System.IO.SearchOption.AllDirectories));
    }
