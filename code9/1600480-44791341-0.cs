    foreach (var channel in channelsListResponse.Items)
    {
    	var uploadsListId = channel.ContentDetails.RelatedPlaylists.Uploads;
    
    	Console.WriteLine("Videos in list {0}", uploadsListId);
    
    	var nextPageToken = "";
    	while (nextPageToken != null)
    	{
    		var playlistItemsListRequest = youtubeService.PlaylistItems.List("snippet");
    		playlistItemsListRequest.PlaylistId = uploadsListId;
    		playlistItemsListRequest.MaxResults = 50;
    		playlistItemsListRequest.PageToken = nextPageToken;
    
    		// Retrieve the list of videos uploaded to the authenticated user's channel.
    		var playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();
    
    		foreach (var playlistItem in playlistItemsListResponse.Items)
    		{
    			var videoRequest = youtubeService.Videos.List("snippet");
    			videoRequest.Id = playlistItem.Snippet.ResourceId.VideoId;
    			videoRequest.MaxResults = 1;
    			var videoItemRequestResponse = await videoRequest.ExecuteAsync();
    
    			// Get the videoID of the first video in the list
    			var video = videoItemRequestResponse.Items[0];
    			var duration = video.ContentDetails.Duration;
    		}
    
    		nextPageToken = playlistItemsListResponse.NextPageToken;
    	}
    }
