    IEnumerable<string> files = Directory.EnumerateFiles(@"C:\local\folder");
    using (WebClient client = new WebClient())
    {
        client.Credentials = new NetworkCredential("username", "password");
        foreach (string file in files)
        {
            client.UploadFile(
                "ftp://example.com/remote/folder/" + Path.GetFileName(file), file);
        }
    }
