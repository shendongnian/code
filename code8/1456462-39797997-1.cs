    var videoBinary = File.ReadAllBytes(@"C:\Users\linvi\Pictures\mov_bbb.mp4");
    var videoMedia = Upload.UploadVideo(videoBinary, "video/mp4", "amplify_video");
    var isProcessed = videoMedia.UploadedMediaInfo.ProcessingInfo.State == "succeeded";
    var timeToWait = videoMedia.UploadedMediaInfo.ProcessingInfo.CheckAfterInMilliseconds;
    while (!isProcessed)
    {
        Thread.Sleep(timeToWait);
                
        // The second parameter (false) informs Tweetinvi that you are manually awaiting the media to be ready
        var mediaStatus = Upload.GetMediaStatus(videoMedia, false);
        isProcessed = mediaStatus.ProcessingInfo.State == "succeeded";
        timeToWait = mediaStatus.ProcessingInfo.CheckAfterInMilliseconds;
    }
