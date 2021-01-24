using (var client = new SftpClient(Config.UnixServer, Config.UnixUsername, Config.UnixPassword))
{
    client.Connect();
    client.UploadFile(new FileInfo(fileUpload).OpenRead(), fileName);
    client.Disconnect();
}
