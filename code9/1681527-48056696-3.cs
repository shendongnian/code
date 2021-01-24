    public bool UploadFile()
    {
    FtpWebRequest objFTP= null;
    try
    {
    objFTP= FTPDetail("File.xlsx");
    objFTP.Method = WebRequestMethods.Ftp.UploadFile;
    using (FileStream fs = File.OpenRead(CompletePath))
    {
    byte[] buff = new byte[fs.Length];
    using (Stream strm = objFTP.GetRequestStream())
    {
    contentLen = fs.Read(buff, 0, buff.Length);
    while (contentLen != 0)
    {
    strm.Write(buff, 0, buff.Length);
    contentLen = fs.Read(buff, 0, buff.Length);
    }
    objFTP = null;
    }
    }
    return true;
    }
    catch (Exception Ex)
    {
    if (objFTP!= null)
    {
    objFTP.Abort();
    }
    throw Ex;
    }
    }
