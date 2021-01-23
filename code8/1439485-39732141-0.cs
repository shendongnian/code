        string bucketName = "your bucket";
        AmazonS3Client s3Client = new AmazonS3Client("your access key", "your secret key", cfg);
        S3DirectoryInfo dir = new S3DirectoryInfo(s3Client, bucketName, "your AmazonS3 folder name");
        foreach (IS3FileSystemInfo file in dir.GetFileSystemInfos())
        {
            Console.WriteLine(file.Name);
            Console.WriteLine(file.Extension);
            Console.WriteLine(file.LastWriteTime);
        }
