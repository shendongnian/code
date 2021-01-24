    var client = new YoutubeClient();
    var video = await client.GetVideoAsync("M1wLtAXDgqg");
    var streamInfo = video.MuxedStreamInfos.First(s => s.Container == Container.Mp4 && s.VideoQuality == VideoQuality.Medium360);
    var path = System.IO.Path.Combine("D:\\", video.Title + "." + streamInfo.Container.GetFileExtension());
    await client.DownloadMediaStreamAsync(streamInfo, path, new Progress<double>(d => Console.WriteLine(d.ToString("p2")));
