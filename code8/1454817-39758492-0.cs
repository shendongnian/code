    public string ftpUpload(HttpPostedFileBase imagefile, string filename)
            {
                var sourceStream = imagefile.InputStream;
                int BUFFER_SIZE = imagefile.ContentLength;
                byte[] buffer = new byte[BUFFER_SIZE];
                int bytesRead = sourceStream.Read(buffer, 0, BUFFER_SIZE);
    
                if (!CheckLogoDimension(sourceStream))
                {
                    sourceStream.Close();
                    return "error";
                }
    
                FtpWebRequest request = (FtpWebRequest)WebRequest.Create(ftpRootPath + "/" + filename);
                request.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
    
                request.Method = WebRequestMethods.Ftp.UploadFile;
    
                Stream requestStream = request.GetRequestStream();
                request.ContentLength = sourceStream.Length;
                do
                {
                    requestStream.Write(buffer, 0, bytesRead);
                    bytesRead = sourceStream.Read(buffer, 0, BUFFER_SIZE);
                } while (bytesRead > 0);
                sourceStream.Close();
                requestStream.Close();
                FtpWebResponse response = (FtpWebResponse)request.GetResponse();
                response.Close();
    
                return "Success";
            }
