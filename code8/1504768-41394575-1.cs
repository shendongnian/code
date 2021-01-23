    private static void ApplyFolderIcon(string targetFolderPath, string iconFilePath)
    {
        var iniPath = Path.Combine(targetFolderPath, "desktop.ini");
        if (File.Exists(targetFolderPath))
        {
            File.Delete(iniPath);
        }
    
        //create new ini file with the required contents
        var iniContents = new StringBuilder()
            .AppendLine("[.ShellClassInfo]")
            .AppendLine($"IconResource={iconFilePath},0")
            .AppendLine($"IconFile={iconFilePath}")
            .AppendLine("IconIndex=0")
            .ToString();
        File.WriteAllText(iniPath, iniContents);
    
        //hide the ini file and set it as system
        File.SetAttributes(
           iniPath, 
           File.GetAttributes(iniPath) | FileAttributes.Hidden | FileAttributes.System );
        //set the folder as system
        File.SetAttributes(
            targetFolderPath, 
            File.GetAttributes(targetFolderPath) | FileAttributes.System );
    }
