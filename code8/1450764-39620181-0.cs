    {
        if (context==null)
        {
            throw new ArgumentNullException("context");
        }
        if (string.IsNullOrEmpty(ftpUri))
        {
            throw new ArgumentNullException("ftpUri");
        }
        if (string.IsNullOrEmpty(user))
        {
            throw new ArgumentNullException("user");
        }
        if (string.IsNullOrEmpty(password))
        {
            throw new ArgumentNullException("password");
        }
        if (filePath==null)
        {
            throw new ArgumentNullException("filePath");
        }
        if (!context.FileSystem.Exist(filePath))
        {
            throw new System.IO.FileNotFoundException("Source file not found.", filePath.FullPath);
        }
        uploadResponseStatus = null;
        var ftpFullPath = string.Format(
            "{0}/{1}",
            ftpUri.TrimEnd('/'),
            filePath.GetFilename()
            );
        var ftpUpload = System.Net.WebRequest.Create(ftpFullPath) as System.Net.FtpWebRequest;
        if (ftpUpload == null)
        {
            uploadResponseStatus = "Failed to create web request";
            return false;
        }
        ftpUpload.Credentials = new System.Net.NetworkCredential(user, password);
        ftpUpload.KeepAlive = false;
        ftpUpload.UseBinary = true;
        ftpUpload.Method = System.Net.WebRequestMethods.Ftp.UploadFile;
        using (System.IO.Stream
            sourceStream = context.FileSystem.GetFile(filePath).OpenRead(),
            uploadStream = ftpUpload.GetRequestStream())
        {
            sourceStream.CopyTo(uploadStream);
            uploadStream.Close();
        }
        var uploadResponse = (System.Net.FtpWebResponse)ftpUpload.GetResponse();
        uploadResponseStatus = (uploadResponse.StatusDescription ?? string.Empty).Trim().ToUpper();
        uploadResponse.Close();
        return  uploadResponseStatus.Contains("TRANSFER COMPLETE") ||
                         uploadResponseStatus.Contains("FILE RECEIVE OK");
    }
