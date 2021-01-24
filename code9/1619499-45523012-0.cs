    var files = File.ReadAllLines("list.txt");
    foreach (var filename in files)
    {
        if (!File.Exists(filename))
        {
            WebClient client = new WebClient();
            client.DownloadFileAsync(new Uri(site + filename), dir + filename);
        }
    }
