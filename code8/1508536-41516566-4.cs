    {  
       "version":"1.1",
       "date":"2017-01-06",
       "count":"130",
       "songs":[  
          {  
             "artist":"Artist 1",
             "title":"Title 1"
          },
          {  
             "artist":"Artist 2",
             "title":"Title 2"
          },
          {  
             "artist":"Artist 3",
             "title":"Title 3"
          }
       ]
    }
    
    public class Song
    {
        public string artist {get; set;}
        public string title {get; set;}
    }
    
    public class SongsResponse
    {
        public string version { get; set; }
        public string date { get; set; }
        public string count {get; set; }
        public List<Song> songs { get; set; }
    }
