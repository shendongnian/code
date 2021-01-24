    void DownloadAudio(string videoUrl, string saveDir)
    {
        YouTube youtube = YouTube.Default;
        Video vid = youtube.GetVideo(videoUrl);
        
        var fullFileName = Path.Combine(saveDir, vid.FullName);
    
        File.WriteAllBytes(fullFileName, vid.GetBytes());
    
        var mediaHelper = DependencyService.Get<IMediaHelper>();
        mediaHelper.ConvertToMp3(fullFileName);
    }
