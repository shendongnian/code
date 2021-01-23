    void UploadDirectory(SftpClient client, string localPath, string remotePath)
    {
        Console.WriteLine("Uploading directory {0} to {1}", localPath, remotePath);
        IEnumerable<FileSystemInfo> infos =
            new DirectoryInfo(localPath).EnumerateFileSystemInfos();
        foreach (FileSystemInfo info in infos)
        {
            if (info.Attributes.HasFlag(FileAttributes.Directory))
            {
                string subPath = remotePath + "/" + info.Name;
                if (!client.Exists(subPath))
                {
                    client.CreateDirectory(subPath);
                }
                UploadDirectory(client, info.FullName, remotePath + "/" + info.Name);
            }
            else
            {
                using (Stream fileStream = new FileStream(info.FullName, FileMode.Open))
                {
                    Console.WriteLine(
                        "Uploading {0} ({1:N0} bytes)", info.FullName, ((FileInfo)info).Length);
                    client.UploadFile(fileStream, remotePath + "/" + info.Name);
                }
            }
        }
    }
