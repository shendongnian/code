    public MainWindow()
	{
		InitializeComponent();
		Player = new MediaUriElement();
		Player.BeginInit();
		Player.EndInit();
		Player.Source = new Uri("[YourPath].m3u8");
		Player.Play();
	}
	public MediaUriElement Player { get; set; }
