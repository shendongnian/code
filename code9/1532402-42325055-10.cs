    var client = new HttpClient();
    client.DefaultRequestHeaders.Range = new RangeHeaderValue(0, 600000);
    using (var stream = await client.GetStreamAsync(video.DownloadUrl))
    using (var output = File.Create(@"C:\Videofile.pm4"))
    {
        await stream.CopyToAsync(output);
    }
