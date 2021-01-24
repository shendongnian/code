    public long TransferFile(string file)
    {
        long filesize = 0L;
    
        try
        {
            string[] newfile = new[] { file };
    
            ConnectionManager ftpCM = Dts.Connections["ftp_server"];
            string remoteDir = Dts.Variables["FtpWorkingDirectory"].Value.ToString();
            string ServerUsername = Dts.Variables["ServerUsername"].Value.ToString();
            string ServerPassword = Dts.Variables["ServerPassword"].Value.ToString();
    
            FtpClientConnection ftpClient = new FtpClientConnection(ftpCM.AcquireConnection(null));
            ftpClient.UsePassiveMode = true;
            ftpClient.ServerUserName = ServerUsername;
            ftpClient.ServerPassword = ServerPassword;
            ftpClient.Connect();
            ftpClient.Retries = 10;
            ftpClient.SetWorkingDirectory(remoteDir);
    
            ftpClient.SendFiles(newfile, remoteDir, true, false);
    
            ftpClient.Close();
    
            FtpWebRequest request = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpCM.ConnectionString + remoteDir + "/" + Path.GetFileName(file)));
            request.Proxy = null;
    
            request.Credentials = new NetworkCredential(ServerUsername, ServerPassword);
            request.Method = WebRequestMethods.Ftp.GetFileSize;
    
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            filesize = response.ContentLength;
            response.Close();
        }
        catch (Exception ex)
        {
            throw ex;
        }
    
        return filesize;
    }
