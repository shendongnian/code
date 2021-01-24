    class Movie
    {
        public int Id {get; set;}
        // a movie has zero or more images:
        public virtual ICollection<Image> Images {get; set;}
        ... // other properties
    }
    class Image
    {
        public int Id {get; set;}
        // every image belongs to exactly one movie using foreign key:
        public int MovieId {get; set;}
        public virtual Movie Movie {get; set;}      
        ... // other properties 
    }
