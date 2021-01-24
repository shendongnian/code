    static void FileShareByteCount(CloudFileDirectory dir,ref long bytesCount)
    {
        FileContinuationToken continuationToken = null;
        FileResultSegment resultSegment = null;
        do
        {
            resultSegment = dir.ListFilesAndDirectoriesSegmented(100, continuationToken, null, null);
            if (resultSegment.Results.Count() > 0)
            {
                foreach (var item in resultSegment.Results)
                {
                    if (item.GetType() == typeof(CloudFileDirectory))
                    {
                        var CloudFileDirectory = item as CloudFileDirectory;
                        Console.WriteLine($" List sub CloudFileDirectory with name：[{CloudFileDirectory.Name}]");
                        FileShareByteCount(CloudFileDirectory,ref bytesCount);
                    }
                    else if (item.GetType() == typeof(CloudFile))
                    {
                        var CloudFile = item as CloudFile;
                        Console.WriteLine($"file name：[{CloudFile.Name}]，size：{CloudFile.Properties.Length}B");
                        bytesCount += CloudFile.Properties.Length;
                    }
                }
            }
        } while (continuationToken != null);
    }
