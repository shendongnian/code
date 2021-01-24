    public class VideoFilesReader : IKnownFolderReader
    {
        private VideoListItem videoItems;
        public async Task<List<VideoListItem>> GetData()
        {
            List<VideoListItem> videoItems = new List<VideoListItem>();
            StorageFolder videos_folder = await KnownFolders.VideosLibrary.GetFolderAsync("Videos");
            var queryOptions = new QueryOptions(CommonFileQuery.DefaultQuery, new[] { ".mp4" });
            var videos = await videos_folder.CreateFileQueryWithOptions(queryOptions).GetFilesAsync();
            foreach (var video in videos)
            {
                var bitmap = new BitmapImage();
                var thumbnail = await video.GetThumbnailAsync(ThumbnailMode.SingleItem);
                await bitmap.SetSourceAsync(thumbnail);
                videoItems.Add(new VideoListItem(video.DisplayName, "", new Uri(video.Path), bitmap));
            }
            return videoItems;
        }
    }
