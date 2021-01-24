    private static async Task<byte[]> GetURLContentsAsync(string url) {
        var content = new MemoryStream();
            
        var webReq = (HttpWebRequest)WebRequest.Create(url);
            
        DateTime responseStart = DateTime.Now;
        using (WebResponse response = await webReq.GetResponseAsync()) {
            Console.WriteLine($"GetResponseAsync time: {(DateTime.Now - responseStart).TotalSeconds}");
            using (Stream responseStream = response.GetResponseStream()) {
                DateTime copyStart = DateTime.Now;
                await responseStream.CopyToAsync(content);
                Console.WriteLine($"CopyToAsync time: {(DateTime.Now - copyStart).TotalSeconds}");
            }
        }
        return content.ToArray();
    }
