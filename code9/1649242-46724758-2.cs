	private DispatcherTimer _timer;
	private SubtitleManager _manager;
	public MainWindow()
	{
		InitializeComponent();
		_manager = new SubtitleManager();
		_manager.SetEntries(new List<SubtitleEntry>()
		{
			new SubtitleEntry{Text = "1s", TimeStamp = TimeSpan.FromSeconds(1)},
			new SubtitleEntry{Text = "2s", TimeStamp = TimeSpan.FromSeconds(2)},
			new SubtitleEntry{Text = "4s", TimeStamp = TimeSpan.FromSeconds(4)},
			new SubtitleEntry{Text = "10s", TimeStamp = TimeSpan.FromSeconds(10)},
			new SubtitleEntry{Text = "12s", TimeStamp = TimeSpan.FromSeconds(12)},
		});
		_manager.UpdateSubtitles += ManagerOnUpdateSubtitles;
	}
	private void ManagerOnUpdateSubtitles(object sender, string s)
	{
		txtSubtitle.Text = s;
	}
	private void Button_Click(object sender, RoutedEventArgs e)
	{
		OpenFileDialog dialog = new OpenFileDialog();
		if (dialog.ShowDialog(this) != true) return;
		element.Source = new Uri(dialog.FileName, UriKind.Absolute);
		_timer = new DispatcherTimer();
		_timer.Tick += Timer_Tick;
		_timer.Interval = new TimeSpan(0,0,0,0,50);
		_timer.Start();
	}
	private void Timer_Tick(object sender, EventArgs eventArgs)
	{
		_manager.UpdateTime(element.Position);
		Debug.WriteLine(element.Position.ToString("g"));
	}
