    private static string GenerateLocalizedName(IKnownFolder shellFolder)
    {
        // Attempt to obtain localized name of folder
        // 1. Directly from KnownFolder
        string localizedName = shellFolder.LocalizedName;
        // 2. From ShellObject (this solves This Computer and Control Panel issue)
        if (String.IsNullOrEmpty(localizedName))
            localizedName = (shellFolder as ShellObject)?.Name;
        // 3. If folder is not virtual, use its localized name from desktop.ini
        if (String.IsNullOrEmpty(localizedName) && Directory.Exists(shellFolder.Path))
        {
            try
            {
                localizedName = WinApiInterop.GetLocalizedName(shellFolder.Path);
            }
            catch
            {
                // Intentionally left empty
            }
        }
        // 4. If folder is not virtual, use its filename
        if (String.IsNullOrEmpty(localizedName) && Directory.Exists(shellFolder.Path))
            localizedName = Path.GetFileName(shellFolder.Path);
        // 5. If anything else fails, use its canonicalName (eg. MyComputerFolder)
        if (String.IsNullOrEmpty(localizedName))
            localizedName = shellFolder.CanonicalName;
        return localizedName;
    }
    private void LoadShellFolders()
    {
        foreach (var shellFolder in KnownFolders.All)
        {
            string localizedName = GenerateLocalizedName(shellFolder);
            string comment = shellFolder.PathExists ? shellFolder.Path : $"shell:{shellFolder.CanonicalName}";
            infos.Add(new ShellFolderInfo(shellFolder.CanonicalName,
                localizedName,
                comment,
                shellFolder.CanonicalName,
                shellFolder.PathExists ? shellFolder.Path : null));
        }
    }
