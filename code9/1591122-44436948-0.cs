    FtpWebRequest request = (FtpWebRequest)WebRequest.Create(destUrl);
    request.Method = WebRequestMethods.Ftp.UploadFile;
    request.Credentials = new NetworkCredential(username, password);
    request.Proxy = null;
    request.UseBinary = false;
    request.UsePassive = true;
    request.KeepAlive = false;
    request.Timeout = 500000;
    using (Stream requestStream = request.GetRequestStream())
    using (StreamWriter sw = new StreamWriter(requestStream))
    {
        if (dt.Rows.Count > 0)
        {
            sw.Write("Column1,Column2");
            sw.Write(sw.NewLine);
            foreach (DataRow dr in dt.Rows)
            {
                sw.Write(dr["Column1"].ToString());
                sw.Write(",");
                sw.Write(dr["Column2"].ToString());
                sw.Write(",");
            }
        }
    }
