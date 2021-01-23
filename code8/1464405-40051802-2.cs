    public partial class Movie : UserControl
    {
        public string Title { get; set; } // for easy matching
    
        public Movie()
        {
            InitializeComponent();
        }
    
        public Movie(Image thumbnail, string title) // use this constructor to make your movie tiles
        {
            InitializeComponent();
            pictureBox1.Image = thumbnail;
            label1.Text = title;
            Title = title;
        }
    }
