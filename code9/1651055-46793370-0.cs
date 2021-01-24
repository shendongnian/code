    public void readSDcard()
    {
        var removableDives = System.IO.DriveInfo.GetDrives()
            //Take only removable drives into consideration as a SD card candidates
            .Where(drive => drive.DriveType == DriveType.Removable)
            .Where(drive => drive.IsReady)
            //If volume label of SD card is always the same, you can identify
            //SD card by uncommenting following line
            //.Where(drive => drive.VolumeLabel == "MySdCardVolumeLabel")
            .ToList();
        if (removableDives.Count == 0)
            throw new Exception("No SD card found!");
        string sdCardRootDirectory;
        if(removableDives.Count == 1)
        {
            sdCardRootDirectory = removableDives[0].RootDirectory.FullName;
        }
        else
        {
            //Let the user select, which drive to use
            Console.Write($"Please select SD card drive letter ({String.Join(", ", removableDives.Select(drive => drive.Name[0]))}): ");
            var driveLetter = Console.ReadLine().Trim();
            sdCardRootDirectory = driveLetter + ":\\";
        }
        var path = Path.Combine(sdCardRootDirectory, "MAX");
        //Here you have all files in that directory
        var allFiles = Directory.EnumerateFiles(path);
        //Select last file (with the greatest number in the file name)
        var lastFile = allFiles
            //Sort files in the directory by number in their file name
            .OrderByDescending(filename =>
            {
                //Convert filename to number
                var fn = Path.GetFileNameWithoutExtension(filename);
                if (Int64.TryParse(fn, out var fileNumber))
                    return fileNumber;
                else
                    return -1;//Ignore files with non-numerical file name
            })
            .FirstOrDefault();
        if (lastFile == null)
            throw new Exception("No file found!");
        string[] fileContents = File.ReadAllLines(lastFile);
        foreach (string line in fileContents)
        {
            Console.WriteLine(line);
        }
    }
