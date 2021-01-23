    var projectDirectoryPath = currentProjectViewModel.DirectoryPath;
    var tempFile = System.IO.Path.GetTempFileName();
    try
    {
        ZipFile.CreateFromDirectory(projectDirectoryPath, tempFile);
        using (var archive = ZipFile.Open(TargetFilePath, ZipArchiveMode.Update))
        {
            archive.CreateEntryFromFile(tempFile, "Project.zip", CompressionLevel.NoCompression);
        }
    }
    finally
    {
        System.IO.File.Delete(tempFile);
    }
