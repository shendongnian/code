    var videoBinary = File.ReadAllBytes("file_path");
    var videoMedia = Upload.UploadVideo(videoBinary);
    Tweet.PublishTweet("test", new PublishTweetOptionalParameters()
    {
        Medias = { videoMedia }
    });
