    private List<Song> SongList;
    
    public Form1()
    {
        InitializeComponent();
        SongList = new List<Song>();
    }
    private void button1_Click(object sender, EventArgs e)
    {
        // Create a new song, add it to the list and add it to the listbox
        Song song = new Song(newTracktextBox.Text, 100);
        SongList.Add(song);
        listBox1.Items.Add(song.TrackName);
    }
    class Song
    {
        public string TrackName { get; }
        private int trackLength;
        public Song(string trackName, int trackLength)
        {
            this.TrackName = trackName;
            this.trackLength = trackLength;
        }
    }
