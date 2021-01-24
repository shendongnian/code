    public abstract class ContentVideoType
    {
        public virtual string Title { get; set; }
        public virtual string GetThumbnail(string id)
        {
            return "Some Default Thumbnail";
        }
    }
    public class YouTubeContentVideType : ContentVideoType
    {
        public override string GetThumbnail(string id)
        {
            return "";//your logic for youTube
        }
    }
    public class VimeoContentVideType : ContentVideoType
    {
        public override string GetThumbnail(string id)
        {
            return "";//your logic for vimeo
        }
    }
