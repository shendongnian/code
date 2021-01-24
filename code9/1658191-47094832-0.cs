    public class AlbumList
    {      
        public int ID { get; set; }
        public int Count { get; set; }
        public string MusicName { get; set; }
        public List<Album> AlbumName { get; set; }
    }
    
    public class Album
    {
        public int AlbumName { get; set; }
    } 
