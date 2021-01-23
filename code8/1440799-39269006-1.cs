    private void UnZipAndCreateUpdatePackage(List<string> FileNameList)
    {
        string CheckPreviousData = System.IO.Path.Combine(fileDestination, WithoutExtentionNameList[0]);
        if (System.IO.Directory.Exists(CheckPreviousData))
        {
            DeleteDirectory(CheckPreviousData);
        }
        if (!System.IO.Directory.Exists(CheckPreviousData))
        {
            System.IO.Directory.CreateDirectory(CheckPreviousData);
        }
        foreach (var FileName in FileNameList)
        {
            if (FileName.Contains("Map"))
            {
                fileDestination = System.IO.Path.Combine(fileDestination, WithoutExtentionNameList[0]);
            }
            //create a source file path
            sourceFile = System.IO.Path.Combine(fileLocation, FileName);
            ZipFile.ExtractToDirectory(sourceFile, fileDestination);
        }
        fileDestination = @"C:\Users\adity\Desktop\MapUpdaterTemp";
        extractNow =false;
    }
