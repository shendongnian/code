    public class ContentVideoType
    {
        public string Title { get; set; }
        public Func<string, string> GetThumbnail { get; set; }
    }
    public static List<ContentVideoType> GetAll
    {
        get
        {
            var result = new List<ContentVideoType> {
                new ContentVideoType
                {
                    Title = "Youtube",
                    GetThumbnail = videoId => $"https://i.ytimg.com/vi/{videoId}/mqdefault.jpg"
                },
                new ContentVideoType
                {
                    Title = "Vimeo",
                    GetThumbnail = videoId => GetVimeoPreview(videoId)
                }
            };
            return result;
        }
    }
