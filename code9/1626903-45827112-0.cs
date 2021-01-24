    public class Movie
    {
        public int Id {set;get;}
        public string Title { get; set; }
        public string Synopsis { get; set; }
        public List<string> Actors { get; set; }
        public DateTime StartDate { get; set; }
        public string MoviePic { get; set; } // path to image
        public int RunningTime { get; set; } // in minutes
        public string Trailer { get; set; } // youtube url
        public int RatingId {set;get;}
        public Rating Rating { set;get;} 
    }
    public class Rating
    {
       public int Id {set;get;}
       public string Name {set;get;} ;
       public string Description {set;get;} ;
       public string LogoImageUrl {set;get;} ;
    }
