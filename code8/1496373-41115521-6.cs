    static void ListFtpDirectory(string url, NetworkCredential credentials)
    {
        WebRequest listRequest = WebRequest.Create(url);
        listRequest.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        listRequest.Credentials = credentials;
        List<string> lines = new List<string>();
        using (WebResponse listResponse = listRequest.GetResponse())
        using (Stream listStream = listResponse.GetResponseStream())
        using (StreamReader listReader = new StreamReader(listStream))
        {
            while (!listReader.EndOfStream)
            {
                string line = listReader.ReadLine();
                lines.Add(line);
            }
        }
        foreach (string line in lines)
        {
            string[] tokens =
                line.Split(new[] { ' ' }, 9, StringSplitOptions.RemoveEmptyEntries);
            string name = tokens[8];
            string permissions = tokens[0];
            if (permissions[0] == 'd')
            {
                Console.WriteLine($"Directory {name}");
                string fileUrl = url + name;
                ListFtpDirectory(fileUrl + "/", credentials);
            }
            else
            {
                Console.WriteLine($"File {name}");
            }
        }
    }
