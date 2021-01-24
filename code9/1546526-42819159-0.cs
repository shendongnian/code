    public class TwitchAPIexample
    {
    
        private const string url = "https://api.twitch.tv/kraken/streams/<channel>";
    
        public bool IsTwitchLive { get; set; }
        public RootObject Root { get; set; }
    
        public TwitchAPIexample()
        {
            BuildConnect();
        }
    
        private void BuildConnect()
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
    
            request.Method = "Get";
            request.Timeout = 12000;
            request.ContentType = "application/json";
            request.Headers.Add("authorization", "<token>");
    
            using (System.IO.Stream s = request.GetResponse().GetResponseStream())
            {
                using (StreamReader sr = new System.IO.StreamReader(s))
                {
                    var jsonResponse = sr.ReadToEnd();
                    this.Root = JsonConvert.DeserializeObject<RootObject>(jsonResponse);
                }
            }
        }
    }
    
    public class Preview
    {
        public string small { get; set; }
        public string medium { get; set; }
        public string large { get; set; }
        public string template { get; set; }
    }
    
    public class Channel
    {
        public bool mature { get; set; }
        public string status { get; set; }
        public string broadcaster_language { get; set; }
        public string display_name { get; set; }
        public string game { get; set; }
        public string language { get; set; }
        public int _id { get; set; }
        public string name { get; set; }
        public string created_at { get; set; }
        public string updated_at { get; set; }
        public bool partner { get; set; }
        public string logo { get; set; }
        public string video_banner { get; set; }
        public string profile_banner { get; set; }
        public object profile_banner_background_color { get; set; }
        public string url { get; set; }
        public int views { get; set; }
        public int followers { get; set; }
    }
    
    public class Stream
    {
        public long _id { get; set; }
        public string game { get; set; }
        public int viewers { get; set; }
        public int video_height { get; set; }
        public int average_fps { get; set; }
        public int delay { get; set; }
        public string created_at { get; set; }
        public bool is_playlist { get; set; }
        public Preview preview { get; set; }
        public Channel channel { get; set; }
    }
    
    public class RootObject
    {
        public Stream stream { get; set; }
    }
