    private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
	{
		if (mediaElement.Source.ToString() == "file:///C:/temp/newGif1.gif")
		{
			mediaElement.Source = new Uri("C:\\temp\\newGif.gif");
            mediaElement.Play();
		}
		else
		{
			mediaElement.Source = new Uri("C:\\temp\\newGif1.gif");
            mediaElement.Play();
		}
	}
