    byte[] video = DownloadBlobFromUrl(parameters.VideoUrl);
    IMedia media = Upload.ChunkUploadBinary(new UploadQueryParameters { Binaries = new List<byte[]> { video }, MediaType = "video/mp4", MediaCategory = "amplify_video", MaxChunkSize = VIDEO_MB_CHUNK_SIZE * 1024 * 1024 });
    publishParameters.Medias = new List<IMedia> { media };
    IUploadedMediaInfo status = Upload.GetMediaStatus(media);
    int numberOfTries = 1;
    while (status.ProcessingInfo.State != "succeeded" && numberOfTries < VIDEO_UPLOAD_TRY_COUNT)
    {
       numberOfTries++;
       await Task.Delay(VIDEO_UPLOAD_WAIT_SECONDS * 1000);
       status = Upload.GetMediaStatus(media);
     }
    if (status.ProcessingInfo.State == "succeeded")
    {
         tweet = Tweet.PublishTweet(message, publishParameters);
         return tweet.IdStr;
     }
