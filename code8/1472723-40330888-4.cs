    void SynchronizeLocalAndFtpDirectory(
             string localPath, string remoteUri, NetworkCredential credentials)
    {
        List<string> remoteFiles = new List<string>();
        FtpWebRequest request = (FtpWebRequest)WebRequest.Create(remoteUri);
        request.Credentials = credentials;
        request.Method = WebRequestMethods.Ftp.ListDirectory;
        using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
        using (StreamReader reader = new StreamReader(response.GetResponseStream()))
        {
            while (!reader.EndOfStream)
            {
                remoteFiles.Add(reader.ReadLine());
            }
        }
        IEnumerable<string> localFiles =
            Directory.GetFiles(localPath).Select(path => Path.GetFileName(path));
        IEnumerable<string> missingFiles = localFiles.Except(remoteFiles);
        foreach (string filename in missingFiles)
        {
            Console.WriteLine("Uploading missing file {0}", filename);
            string remoteFileUri = remoteUri + filename;
            string localFilePath = Path.Combine(localPath, filename);
            FtpWebRequest uploadRequest = (FtpWebRequest)WebRequest.Create(remoteFileUri);
            uploadRequest.Method = WebRequestMethods.Ftp.UploadFile;
            uploadRequest.Credentials = credentials;
            using (Stream targetStream = uploadRequest.GetRequestStream())
            using (Stream sourceStream = File.OpenRead(localFilePath))
            {
                byte[] buffer = new byte[10240];
                int read;
                while ((read = sourceStream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    targetStream.Write(buffer, 0, read);
                }
            }
        }
    }
