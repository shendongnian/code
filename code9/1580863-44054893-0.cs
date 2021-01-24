    async Task<List<Bitmap>> getImages()
    {
        var images = new List<Bitmap>();
        using (var client = new HttpClient())
        {
            var response = await client.GetAsync("http://i.imgur.com/BsPzIfs.png");
            var bitmap = new Bitmap();
            if (response != null && response.StatusCode == HttpStatusCode.OK)
            {
                using (var stream = await response.Content.ReadAsStreamAsync())
                {
                    var memStream = new MemoryStream();
                    await stream.CopyToAsync(memStream);
                    memStream.Position = 0;
                    images.Add(new Bitmap(memStream);
                }
            }
        }
        return images;
    }   
