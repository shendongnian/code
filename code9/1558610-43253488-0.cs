    using (var webCon = new WebClient()) 
    {
        string webData = webCon.DownloadString("URL");
        //process webData
    }
