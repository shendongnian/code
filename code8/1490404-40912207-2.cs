    private List<Song> SongList;
    
    public Form1()
    {
        InitializeComponent();
        SongList = new List<Song>();
    }
    private void button1_Click(object sender, EventArgs e)    
    {
        Song song = new Song("SongName", 100);
        SongList.Add(song);
        listBox1.Items.Add(song); // The trackName will be shown because we are doing a override on the ToString() in the Song class
    }
    class Song
    {
        private string trackName;
        private int trackLength;
        public Song(string trackName, int trackLength)
        {
            this.trackName = trackName;
            this.trackLength = trackLength;
        }
        public override string ToString()
        {
            return trackName;
            // Case you want to show more...
            // return trackName + ": " +  trackLength;
        }
    }
