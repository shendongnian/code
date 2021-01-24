    private static void RemoveVideo(YouTubeService youTubeService, string playlistId, string videoId)
    {
        // Find the matching video item
        var videos = youTubeService.PlaylistItems.List("snippet");
        videos.PlaylistId = playlistId;
    
        var video = videos.Execute().Items.Where(a => a.Snippet.ResourceId.VideoId == videoId).SingleOrDefault();
    
        if (video == null)
        {
            throw new ArgumentException("Video not found!", nameof(videoId));
        }
    
        // Now delete it by it's inner ID
        var playlistInsertRequest = youTubeService.PlaylistItems.Delete(video.Id);
        playlistInsertRequest.Execute();
    }
