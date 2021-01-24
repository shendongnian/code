    byte[] data;
    using (var client = new WebClient())
    {
        data = client.DownloadData(thumb);
    }
    File.WriteAllBytes($"{Path.GetTempPath()}\\xyz.jpg", data);
