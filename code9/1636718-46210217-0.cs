    class Album
    {
        public string AlbumName { get; set; }
        public ObservableCollection<Song> Songs { get; set; }
    }
    public class Song
    {
        public string SongName { get; set; }
        public string FilePath { get; set; }
    }
