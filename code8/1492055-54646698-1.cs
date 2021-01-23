    public static void Copy(string sourceDirectory, string targetDirectory)
    {
        DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
        DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);
        CopyAll(diSource, diTarget);
    }
    
    private static void CopyAll(DirectoryInfo source, DirectoryInfo target)
    {
        Directory.CreateDirectory(target.FullName);
        // Copy each file into the new directory.
        foreach (FileInfo fi in source.GetFiles())
        {
            var destinationFile = Path.Combine(target.FullName, fi.Name);
            fi.CopyTo(destinationFile, true);
        }
        // Copy each subdirectory using recursion.
        foreach (DirectoryInfo diSourceSubDir in source.GetDirectories())
        {
            DirectoryInfo nextTargetSubDir = target.CreateSubdirectory(diSourceSubDir.Name);
            CopyAll(diSourceSubDir, nextTargetSubDir);
        }
    }
    public static void Delete(string sourceDirectory, string targetDirectory)
    {
        DirectoryInfo diSource = new DirectoryInfo(sourceDirectory);
        DirectoryInfo diTarget = new DirectoryInfo(targetDirectory);
    
        DeleteAll(diSource, diTarget);
    }
    
    private static void DeleteAll(DirectoryInfo source, DirectoryInfo target)
    {
        if (!source.Exists)
        {
            target.Delete(true);
            return;
        }
        // Delete each existing file in target directory not existing in the source directory.
        foreach (FileInfo fi in target.GetFiles())
        {
            var sourceFile = Path.Combine(source.FullName, fi.Name);
            if (!File.Exists(sourceFile)) //Source file doesn't exist, delete target file
            {
                fi.Delete();
            }
        }
        // Delete non existing files in each subdirectory using recursion.
        foreach (DirectoryInfo diTargetSubDir in target.GetDirectories())
        {
            DirectoryInfo nextSourceSubDir = new DirectoryInfo(Path.Combine(source.FullName, diTargetSubDir.Name));
            DeleteAll(nextSourceSubDir, diTargetSubDir);
        }
    }
