	public static List<String> Playlist = new List<string>();
	public static void AddToPlaylist(string path)
	{
		Playlist.Add(path);
		Console.WriteLine("Queued " + path);
	}
	public static void RunPlaylist()
	{
		try
		{
			PlayStateStopped = false;
			PlayAudioClip(Playlist.First());
			Playlist.Remove(Playlist.First());
		}
		catch
		{
			WriteFancyConsoleLine("Playlist is empty.", ConsoleColor.Red);
		}
	}
	private void Wplayer_PlayStateChange(int NewState)
	{
		switch (NewState)
		{
			case 0:
				WriteFancyConsoleLine("PlayState = wmppsUndefined", ConsoleColor.DarkGray);
				break;
			case 1:
				WriteFancyConsoleLine("PlayState = wmppsStopped", ConsoleColor.Red);
				PlayStateStopped = true;
				break;
			case 2:
				WriteFancyConsoleLine("PlayState = wmppsPaused", ConsoleColor.Yellow);
				break;
			case 3:
				WriteFancyConsoleLine("PlayState = wmppsPlaying", ConsoleColor.Green);
				break;
			case 4:
				WriteFancyConsoleLine("PlayState = wmppsScanForward", ConsoleColor.DarkMagenta);
				break;
			case 5:
				WriteFancyConsoleLine("PlayState = wmppsScanReverse", ConsoleColor.Magenta);
				break;
			case 6:
				WriteFancyConsoleLine("PlayState = wmppsBuffering", ConsoleColor.Gray);
				break;
			case 7:
				WriteFancyConsoleLine("PlayState = wmppsWaiting", ConsoleColor.DarkYellow);
				break;
			case 8:
				WriteFancyConsoleLine("PlayState = wmppsMediaEnded", ConsoleColor.DarkRed);
				break;
			case 9:
				WriteFancyConsoleLine("PlayState = wmppsTransitioning", ConsoleColor.DarkGray);
				break;
			case 10:
				WriteFancyConsoleLine("PlayState = wmppsReady", ConsoleColor.Magenta);
				break;
			case 11:
				WriteFancyConsoleLine("PlayState = wmppsReconnecting", ConsoleColor.Magenta);
				break;
			case 12:
				WriteFancyConsoleLine("PlayState = wmppsLast", ConsoleColor.DarkBlue);
				break;
		}
	}
	
	public static void PlayAudioClip(string path)
	{
		WriteFancyConsoleLine("Playing " + path, ConsoleColor.Gray);
		wplayer.controls.stop();
		wplayer.URL = path;
		wplayer.controls.play();
		PlayStateStopped = false;
	}
	
	// Remember that timer1.Enabled = true; has to be set somewhere.
	private void timer1_Tick(object sender, EventArgs e)
	{
		if (PlayStateStopped)
		{
			RunPlaylist();
		}
	}
