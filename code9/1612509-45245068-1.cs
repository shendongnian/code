    // Encrypts all files in all the directories (and their sub directories)
    private static void EncryptDirectories(List<string> directoryPaths)
    {
        if (directoryPaths == null) return;
        foreach (var directoryPath in directoryPaths)
        {
            EncryptDirectoryFiles(new DirectoryInfo(directoryPath));
        }
    }
    // Encrypts all files in the specified directory and it's sub directories
    private static void EncryptDirectoryFiles(DirectoryInfo directory)
    {
        if (directory == null) return;
        if (directory.Exists)
        {
            foreach (var file in directory.EnumerateFiles())
            {
                // Pseudo encryption of file by adding an unknown extension
                File.Move(file.FullName, file.FullName + ".encrypted");
            }
            // Recursively process any sub-directories
            foreach(var subDirectory in directory.EnumerateDirectories())
            {
                EncryptDirectoryFiles(subDirectory);
            }
        }
    }
