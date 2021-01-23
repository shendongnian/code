       List<string> strList = new List<string>();
      FtpWebRequest fwr = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP));
      fwr.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
      fwr.Method = WebRequestMethods.Ftp.ListDirectory;
        //Can object of type StreamReader as given below
      StreamReader sr = new StreamReader(fwr.GetResponse().GetResponseStream());  
      string str = sr.ReadLine();
            while (str != null)
            {
                strList.Add(str);
                str = sr.ReadLine();
            }
            Console.WriteLine(strList.Count);
