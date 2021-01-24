	private Dictionary<string, string> _songs = new Dictionary<string, string>()
	{
		{ "item1", "24K Magic" },
		{ "item2", "Summer Air" },
		{ "item3", "Vampire" },
		{ "item4", "Happy" },
	};
	
	private Random _random = new Random();
	
	private void playMusic_Click(object sender, RoutedEventArgs e)
	{
		if (MylistBox.SelectedItem == null)
		{
			MylistBox.SelectedItem = _songs.ElementAt(_random.Next(0, _songs.Count())).Key;
		}
		mediaElement_music.Source = new Uri(String.Format(
			"ms-appx:///Assets/{0}.mp3",
			_songs[(string)MylistBox.SelectedItem]));
	}
