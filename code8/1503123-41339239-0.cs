    //specific path provided by user
    string pth = @"somepath";
    using (System.Net.WebClient client = new System.Net.WebClient())
    {
        client.DownloadFile("http://SomeName/XmlFiles/1554263.xml", pth + "some.xml");
    }
