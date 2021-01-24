            void Main()
            {           
                foreach (var videoType in GetAll)
                {
                    Console.WriteLine(videoType.Title + " " + videoType.GetThumbnail("1")));
                }
            }
            public abstract class ContentVideoType
            {
                public virtual string Title { get; }
                public virtual string GetThumbnail(string id)
                {
                    return "Some Default Thumbnail";
                }
            }
            public class YouTubeContentVideoType : ContentVideoType
            {
                public override string Title { get; } = "Youtube"; 
                public override string GetThumbnail(string id)
                {
                    return $"https://i.ytimg.com/vi/{id}/mqdefault.jpg";
                }
            }
            public class VimeoContentVideType : ContentVideoType
            {
                public override string Title { get; } = "Vimeo";
                public override string GetThumbnail(string id)
                {
                    return GetVimeoPreview(id);
                }
                public string GetVimeoPreview(string videoId)
                {
                    return $"url:{videoId}"; //your code here;
                }
            }
            public static List<ContentVideoType> GetAll
            {
                get
                {
                    var result = new List<ContentVideoType>
                    {
                        new YouTubeContentVideoType(),
                        new VimeoContentVideType()
                    };
                    return result;
                }
            }
