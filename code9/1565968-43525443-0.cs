    public class Consumer
    {
        public string _id { get; set; }
        public string amazon_user_id { get; set; }
        public string birthday { get; set; }
        public string braintree_id { get; set; }
        public string created_at { get; set; }
        public string email { get; set; }
        public string name { get; set; }
        public string pass_count { get; set; }
        public string password_token { get; set; }
        public string playlist_count { get; set; }
        public string remember_token { get; set; }
        public string rss_token { get; set; }
        public string sex { get; set; }
        public string site_id { get; set; }
        public string stripe_id { get; set; }
        public string subscription_count { get; set; }
        public string terms { get; set; }
        public string transaction_count { get; set; }
        public string updates { get; set; }
        public string video_count { get; set; }
        public List<string> linked_devices { get; set; }
    }
    public class Pagination
    {
        public string current { get; set; }
        public string previous { get; set; }
        public string next { get; set; }
        public string per_page { get; set; }
        public string pages { get; set; }
    }
