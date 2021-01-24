    class User
    {
        public int Id {get; set;}    // primary key
        // a User has zero or more Posts:
        public virtual ICollectioins<Post> Posts {get; set;}
        ...
    }
    class Post
    {
        public int Id {get; set;}    // primary key
        // Every Post belongs to exactly one User via foreign key
        public User User {get; set;}
        public int UserId {get; set;}
        // a Post has zero or more Votes (many-to-many)
        public virtual ICollection<Vote> Votes{get; set;}
        ...
    }
    class Vote
    {
        public int Id {get; set;}    // primary key
        // A vote is for zero or more Posts (many-to-many)
        public virtual ICollection<Post> Posts{get; set;}
        public bool Seen {get; set;}
    }
