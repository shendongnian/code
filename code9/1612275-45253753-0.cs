    using (var client = new SftpClient(host, username, password))
    {
        client.Connect();
        using (var fileStream = new FileStream(uploadFile, FileMode.Open))
        {
            client.UploadFile(fileStream, Path.GetFileName(uploadFile));
        }
    }
