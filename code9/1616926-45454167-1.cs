    public Uri MovieUri { get; set; }
        
        public MainWindow()
        {
            MovieUri = new Uri("movie.mp4", UriKind.Relative);
            InitializeComponent();            
        }
