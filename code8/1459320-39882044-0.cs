    HttpWebRequest wr = (HttpWebRequest)WebRequest.Create(strURLFileandPath);
    using (HttpWebResponse ws = (HttpWebResponse)wr.GetResponse())
    using (Stream str = ws.GetResponseStream())
    using (FileStream fstr = new FileStream(strFileSaveFileandPath, FileMode.OpenOrCreate, FileAccess.Write))
    {
    	byte[] inBuf = new byte[100000];
    	int bytesRead = 0;
    	while ((bytesRead = str.Read(inBuf, 0, inBuf.Length)) > 0)
    		fstr.Write(inBuf, 0, bytesRead);
    }
