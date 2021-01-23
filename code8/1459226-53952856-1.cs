    private void SaveMP3(string SaveToFolder, string VideoURL, string MP3Name)
    {
        var source = @SaveToFolder;
        var youtube = YouTube.Default;
        var vid = youtube.GetVideo(VideoURL);
        File.WriteAllBytes(source + vid.FullName, vid.GetBytes());
        var inputFile = new MediaFile { Filename = source + vid.FullName };
        var outputFile = new MediaFile { Filename = $"{MP3Name}.mp3" };
        using (var engine = new Engine())
        {
            engine.GetMetadata(inputFile);
            engine.Convert(inputFile, outputFile);
        }
    }
 
