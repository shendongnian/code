    public class Rootobject
    {
        public User user { get; set; }
        public string logging_page_id { get; set; }
    }
    public class User
    {
        public string biography { get; set; }
        public bool blocked_by_viewer { get; set; }
        public bool country_block { get; set; }
        public string external_url { get; set; }
        public string external_url_linkshimmed { get; set; }
        public Followed_By followed_by { get; set; }
        public bool followed_by_viewer { get; set; }
        public Follows follows { get; set; }
        public bool follows_viewer { get; set; }
        public string full_name { get; set; }
        public bool has_blocked_viewer { get; set; }
        public bool has_requested_viewer { get; set; }
        public string id { get; set; }
        public bool is_private { get; set; }
        public bool is_verified { get; set; }
        public string profile_pic_url { get; set; }
        public string profile_pic_url_hd { get; set; }
        public bool requested_by_viewer { get; set; }
        public string username { get; set; }
        public object connected_fb_page { get; set; }
        public Media media { get; set; }
    }
    public class Followed_By
    {
        public int count { get; set; }
    }
    public class Follows
    {
        public int count { get; set; }
    }
    public class Media
    {
        public Node[] nodes { get; set; }
        public int count { get; set; }
        public Page_Info page_info { get; set; }
    }
    public class Page_Info
    {
        public bool has_next_page { get; set; }
        public string end_cursor { get; set; }
    }
    public class Node
    {
        public string __typename { get; set; }
        public string id { get; set; }
        public bool comments_disabled { get; set; }
        public Dimensions dimensions { get; set; }
        public object gating_info { get; set; }
        public string media_preview { get; set; }
        public Owner owner { get; set; }
        public string thumbnail_src { get; set; }
        public object[] thumbnail_resources { get; set; }
        public bool is_video { get; set; }
        public string code { get; set; }
        public int date { get; set; }
        public string display_src { get; set; }
        public string caption { get; set; }
        public Comments comments { get; set; }
        public Likes likes { get; set; }
        public int video_views { get; set; }
    }
    public class Dimensions
    {
        public int height { get; set; }
        public int width { get; set; }
    }
    public class Owner
    {
        public string id { get; set; }
    }
    public class Comments
    {
        public int count { get; set; }
    }
    public class Likes
    {
        public int count { get; set; }
    }
