    public void DownloadPdf(localFilePath)
    {
        DropboxClient client2 = new DropboxClient("cU5M-asdgfsdfsdfds3434435dfgfgvXoAMCFyOXH");
        string folder = "MyFolder";
        string file = "Test PDF.pdf";
        using (var response = await client.Files.DownloadAsync("/" + folder + "/" + file))
        {
            using (var fileStream = File.Create(localFilePath))
            {
                response.GetContentAsStreamAsync().Result.CopyTo(fileStream);
            }
        }
    }
