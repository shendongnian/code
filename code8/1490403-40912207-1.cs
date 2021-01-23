    private BindingList<Song> SongList;
    
    public Form1()
    {
        InitializeComponent();
        // Initialise a new list and bind it to the listbox
        SongList = new BindingList<Song>();
        listBox1.DataSource = SongList;
    }
  
    private void button1_Click(object sender, EventArgs e)
    {
        // Create a new song and add it to the list, 
        // the listbox will automatically update accordingly
        Song song = new Song("SongName", 100);
        SongList.Add(song);
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
        }
    }
