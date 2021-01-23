    string bucketName = your bucket name;
    S3DirectoryInfo dir = new S3DirectoryInfo(client, bucketName, "folder name");
    foreach (IS3FileSystemInfo file in dir.GetFiles())
    {
        Console.WriteLine(file.Name);
        Console.WriteLine(file.Extension);
        Console.WriteLine(file.LastWriteTime);
    }
