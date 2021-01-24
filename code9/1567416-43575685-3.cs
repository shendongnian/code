    public class TwitterUserModel
    {
        public TwitterUserModel(TwitterUser user)
        {
            this.TwitterUser = user;
        }
    
        public string AnotherPropertyNeededByView {get; set;}
    
        public TwitterUser TwitterUser { get; set; }
    }
