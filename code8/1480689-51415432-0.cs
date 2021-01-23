    <!-- language: lang-cs -->
    public static byte[] DownloadFile(string url, string filePath, string user, string password)
            {
                var ftpServerUrl = string.Concat(url, filePath);
                var request = (FtpWebRequest) WebRequest.Create(ftpServerUrl);
                request.Method = WebRequestMethods.Ftp.DownloadFile;
                
                request.Credentials = new NetworkCredential(user,password);
                using (var response = (FtpWebResponse) request.GetResponse())
                using (var responseStream = response.GetResponseStream())
                using (var memoryStream = new MemoryStream())
                {
                    responseStream?.CopyTo(memoryStream);
                    return memoryStream.ToArray();
                }
            }
