    string url = "domain.com/myfile.php";
    using (WebClient client = new WebClient())
    {
        string html = client.DownloadString(url);
        lines = Regex.Split(html, @"\r?\n|\r");
        client.Dispose();
    }
