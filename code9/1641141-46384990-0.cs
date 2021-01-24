    private ListFolderResult ListFolder(DropboxClient client, string path)
    {
        Console.WriteLine("--- Files ---");
        var list = client.Files.ListFolderAsync(path);
        list.Wait();
        return list.Result;
    }
