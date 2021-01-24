    public void UploadSFTPFile(string sourcefile, string destinationpath)
    {
        using (SftpClient client = new SftpClient(host, port, username, password))
        {
            client.Connect();
            using (FileStream fs = new FileStream(sourcefile, FileMode.Open))
            {
                client.UploadFile(fs, destinationpath + Path.GetFileName(sourcefile));
            }
        }
    }
