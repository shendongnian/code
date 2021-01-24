    if(!System.IO.File.Exists(url)
    {
        //code that handles the file dne case.. maybe log and return?
    }
    using (var client = new WebClient())
    {
        client.DownloadFile(url, path);
    }
