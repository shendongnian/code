        public async Task<List<Video>> GetVideoListAsync(ChannelListMethod Method, string MethodValue, int? MaxVideos)
        {
            // Define variables needed for this method
            List<string> videoIdList = new List<string>();
            List<Video> videoList = new List<Video>();
            string uploadsListId = null;
            // Make sure values passed into the method are not null or empty.
            if (MaxVideos == null)
            {
                throw new ArgumentNullException(nameof(MaxVideos));
            }
            if (string.IsNullOrEmpty(MethodValue))
            {
                return videoList;
            }
            // Create the service.
            using (YouTubeService youtubeService = new YouTubeService(new BaseClientService.Initializer
            {
                ApiKey = _apiKey,
                ApplicationName = _appName
            }))
            {
                // Step ONE is to get a list of channels for a specified YouTube user or ChannelID.
                // Create the FIRST Request object to get a list of YouTube Channels and get their contentDetails
                // based on either ForUserName or ChannelID.
                ChannelsResource.ListRequest channelsListRequest = youtubeService.Channels.List("contentDetails");
                if (Method == ChannelListMethod.ForUserName)
                {
                    // Build the ChannelListRequest using UserName
                    channelsListRequest.ForUsername = MethodValue;
                }
                else
                {
                    // Build the ChannelListRequest using ChannelID
                    channelsListRequest.Id = MethodValue;
                }
                // This is the FIRST Request to the YouTube API.
                // Retrieve the contentDetails part of the channel resource to get a list of channel IDs.
                // We are only interested in the Uploads playlist of the first channel.
                try
                {
                    ChannelListResponse channelsListResponse = await channelsListRequest.ExecuteAsync();
                    uploadsListId = channelsListResponse.Items[0].ContentDetails.RelatedPlaylists.Uploads;
                }
                catch (Exception ex)
                {
                    ErrorException = ex;
                    return videoList;
                }
                // Step TWO is to get a list of playlist items from the Uploads playlist.
                // From the API response, use the Uploads playlist ID (uploadsListId) to be used to get list of videos
                // from the videos uploaded to the user's channel.
                string nextPageToken = "";
                while (nextPageToken != null)
                {
                    // Create the SECOND Request object for requestring a list of Playlist items
                    // from the channel's Uploads playlist.
                    // Limit the list to maxVideos items and continue to iterate through the pages.
                    PlaylistItemsResource.ListRequest playlistItemsListRequest = youtubeService.PlaylistItems.List("contentDetails");
                    playlistItemsListRequest.PlaylistId = uploadsListId;
                    playlistItemsListRequest.MaxResults = MaxVideos;
                    playlistItemsListRequest.PageToken = nextPageToken;
                    // This is the SECOND Request to YouTube and get a Response object containing
                    // the playlist items in the channel's Uploads playlist.
                    // Then iterate through the Response items to build a string list of the video IDs
                    try
                    {
                        PlaylistItemListResponse playlistItemsListResponse = await playlistItemsListRequest.ExecuteAsync();
                        foreach (PlaylistItem playlistItem in playlistItemsListResponse.Items)
                        {
                            videoIdList.Add(playlistItem.ContentDetails.VideoId.ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        ErrorException = ex;
                        return videoList;
                    }
                    // Now that we have a collection (string array) of video IDs,
                    // Step THREE is to retrieve the snippet, contentDetails, and statistics parts of the 
                    // list of videos uploaded to the authenticated user's channel.
                    try
                    {
                        // Create the THIRD Request object for requestring a list of videos and their associated metadata.
                        var VideoListRequest = youtubeService.Videos.List("snippet, contentDetails, statistics");
                        // The next line converts the list of video Ids to a comma seperated string array of the video IDs
                        VideoListRequest.Id = String.Join(",", videoIdList);
                        VideoListRequest.MaxResults = MaxVideos;
                        var VideoListResponse = await VideoListRequest.ExecuteAsync();
                        // This is the THIRD Request to the YouTube API to get a Response object
                        // containing Collect each Video duration and convert to a usable time format.
                        foreach (var video in VideoListResponse.Items)
                        {
                            video.ContentDetails.Duration = HMSToTimeSpan(video.ContentDetails.Duration).ToString();
                            videoList.Add(video);
                        }
                        // request next page
                        nextPageToken = VideoListResponse.NextPageToken;
                    }
                    catch (Exception ex)
                    {
                        ErrorException = ex;
                        return videoList;
                    }
                }
                return videoList;
            }
        }
