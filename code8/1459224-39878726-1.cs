    var source = @"<your destination folder>";
    var youtube = YouTube.Default;
    var vid = youtube.GetVideo("<video url>");
    File.WriteAllBytes(source + vid.FullName, vid.GetBytes());
    var inputFile = new MediaFile { Filename = source + vid.FullName };
    var outputFile = new MediaFile { Filename = $"{source + vid.FullName}.mp3" };
    using (var engine = new Engine())
    {
        engine.GetMetadata(inputFile);
                
        engine.Convert(inputFile, outputFile);
    }
