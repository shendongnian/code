    public async Task<List<byte[]>> GetAllEvents()
    {
        var list = new List<byte[]>();
        for (int i = 0; i < 5; i++)
        {
            var byteArray = await Task.Run(() => System.IO.File.ReadAllBytes(@"filePath"));
            list.Add(byteArray);
        }
        return list;
    }
