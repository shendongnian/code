    string path = "@C:\Files\Test\Folder";
    string filePath = path +"\\test.txt";
    if (!Directory.Exists(path))
    {
       Directory.CreateDirectory(path);
    }
    WebClient webClient = new WebClient();
    webClient.DownloadFileAsync(new Uri(urlDownload),filePath);
