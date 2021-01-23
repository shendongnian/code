    public static void uploadToFTP (XmlDocument xml)
    {
        using(FtpWebRequest request = (FtpWebRequest)WebRequest.Create("your FTP URL"))
        {
            request.Method = WebRequestMethods.Ftp.UploadFile;
    
            // Insert your credentials here.
            request.Credentials = new NetworkCredential ("username","password");
    
            // Copy the contents of the file to the request stream.
            request.ContentLength = xml.OuterXml.Length;
    
            Stream requestStream = request.GetRequestStream();
            xml.Save(requestStream);
            requestStream.Close();
    
            FtpWebResponse response = (FtpWebResponse)request.GetResponse();
            response.Close();
        }
    }
