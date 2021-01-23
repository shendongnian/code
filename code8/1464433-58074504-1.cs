    var videoFilePath = "myVideo.mp4";
    var videoAnalyer = new VideoAnalyzer();
    var analyzeResult = videoAnalyer.GetVideoInfo(videoFilePath);
    if (analyzeResult.Successful)
    {
        var videoInfo = analyzeResult.VideoInfo;
    }
    else
    {
        // Error handling here
        System.Console.WriteLine(analyzeResult.ErrorMessage);
    }
