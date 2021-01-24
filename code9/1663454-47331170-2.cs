    void ListFtpDirectory(
        string url, string rootPath, NetworkCredential credentials, List<string> list)
    {
        FtpWebRequest listRequest = (FtpWebRequest)WebRequest.Create(url + rootPath);
        listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        listRequest.Credentials = credentials;
        List<string> lines = new List<string>();
        using (FtpWebResponse listResponse = (FtpWebResponse)listRequest.GetResponse())
        using (Stream listStream = listResponse.GetResponseStream())
        using (StreamReader listReader = new StreamReader(listStream))
        {
            while (!listReader.EndOfStream)
            {
                lines.Add(listReader.ReadLine());
            }
        }
        foreach (string line in lines)
        {
            string[] tokens =
                line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[8];
            string permissions = tokens[0];
            string filePath = rootPath + name;
            if (permissions[0] == 'd')
            {
                ListFtpDirectory(url, filePath + "/", credentials, list);
            }
            else
            {
                list.Add(filePath);
            }
        }
    }
