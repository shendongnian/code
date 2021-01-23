    using (WebClient client = new WebClient())
    {
        // Get the website HTML.
        string html = client.DownloadString("http://[website that contains the download link]");
        // Scrape the HTML to find the download URL (see below).
        // Download the desired file.
        client.DownloadFile(downloadLink, Dir.FullName + "\\setup.exe");
    }
