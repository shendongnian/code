    public class Album
    {
        public string AlbumName { get; set; }
        public List<Song> Songs { get; set; } = new List<Song>;
        public Artist AlbumArtist { get; set; }
    }
