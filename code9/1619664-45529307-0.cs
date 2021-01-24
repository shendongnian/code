    public class User
    {
            public string biography { get; set; }
            public bool blocked_by_viewer { get; set; }
            public bool country_block { get; set; }
            public string external_url { get; set; }
            public string external_url_linkshimmed { get; set; }
            public FollowedBy followed_by { get; set; }
            public string followed_by_viewer { get; set; }
            public Follow follows { get; set; }
    }
    
    public class FollowedBy
    {
        public int count { get; set; }
    }
    public class Follow
    {
        public int count { get; set; }
    }
