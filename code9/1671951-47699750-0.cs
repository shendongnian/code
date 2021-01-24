    private async Task<string> GetDataAsString(HttpContent content)
    {
        if (content == null)
            return null;
        using (var str = await content.ReadAsStreamAsync())
        {
            if (str.CanSeek)
                str.Seek(0, System.IO.SeekOrigin.Begin);
            using (var rdr = new StreamReader(str))
            {
                return rdr.ReadToEnd();
            }
        }
    }
