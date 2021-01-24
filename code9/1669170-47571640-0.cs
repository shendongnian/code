    using (var client = new SftpClient(connectionInfo))
    {
        client.Connect();
    
        System.IO.MemoryStream mem = new System.IO.MemoryStream();
    
        client.DownloadFile("filename.xml", mem);
        // Set stream position
        mem.Position = 0;
        using(XmlReader reader = XmlReader.Create(mem))
        {
            var docc = new XmlDocument();
            docc.Load(mem);
        }
    
        client.Disconnect();
    }
