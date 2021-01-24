    public byte[] DownloadFile(string remoteFile)
        {
            try
            {
                ftpRequest = (FtpWebRequest)FtpWebRequest.Create(ip + '/' + remoteFile);
                ftpRequest.Credentials = new NetworkCredential(user, pass);
                ftpRequest.UseBinary = true;
                ftpRequest.UsePassive = true;
                ftpRequest.KeepAlive = true;
                ftpRequest.Method = WebRequestMethods.Ftp.DownloadFile;
                ftpResponse = (FtpWebResponse)ftpRequest.GetResponse();
                ftpStream = ftpResponse.GetResponseStream();
                //byte[] byteBuffer = new byte[Convert.ToInt32(getFileSize(remoteFile))];
                MemoryStream ms = new MemoryStream();
                ftpStream.CopyTo(ms);
                ftpStream.Close();
                ftpResponse.Close();
                ftpRequest = null;                
                Console.WriteLine("Successful");
                return ms.ToArray();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex);
                byte[] bytes = new byte[0];
                return bytes;
            }
        }
