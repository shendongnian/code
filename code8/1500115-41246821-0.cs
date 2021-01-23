    private void volBtn_Tapped(object sender, Windows.UI.Xaml.Input.TappedRoutedEventArgs e)
	{
		switch(mediaElement2.CurrentState)
		{
			case MediaElementState.Playing:
				mediaElement2.Pause();
				break;
			case MediaElementState.Paused:
				mediaElement2.Play();
				break;
		}
	}
