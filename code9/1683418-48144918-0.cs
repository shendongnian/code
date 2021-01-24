    public class Album
    {
        public string AlbumName { get; set; }
        public List<Song> Songs { get; set; }
        public Artist AlbumArtist { get; set; }
        public Album(){
             Songs = new List<Song>();
        }
    }
