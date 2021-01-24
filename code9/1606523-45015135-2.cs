    	private void mediaElement_Loaded(object sender, RoutedEventArgs e)
		{
			mediaElement.Play();
			mediaElement.Position = TimeSpan.FromMilliseconds(100);
			mediaElement.Pause();
		}
		private void mediaElement_MouseEnter(object sender, MouseEventArgs e)
		{
			mediaElement.Play();
			mediaElement.Position = TimeSpan.Zero;
		}
		private void mediaElement_MouseLeave(object sender, MouseEventArgs e)
		{
			mediaElement.Position = TimeSpan.FromMilliseconds(100);
			mediaElement.Pause();
		}
		private void mediaElement_MediaEnded(object sender, RoutedEventArgs e)
		{
			mediaElement.Position = TimeSpan.Zero;
			mediaElement.Play();
		}
