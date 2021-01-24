    // If an entity class is derived from ISelfGeneratedId,
    // entity framework should not generate Ids
    interface ISelfGeneratedId
    {
        public long Id {get; set;}
    }
    class Blog : ISelfGeneratedId
    {
        public long Id {get; set;}          // Primary key
        // a Blog has zero or more Posts:
        public virtual ICollection><Post> Posts {get; set;}
        public string Author {get; set;}
        ...
    }
    class Post : ISelfGeneratedId
    {
        public long Id {get; set;}           // Primary Key
        // every Post belongs to one Blog:
        public long BlogId {get; set;}
        public virtual Blog Blog {get; set;}
        public string Title {get; set;}
        ...
    }
   
