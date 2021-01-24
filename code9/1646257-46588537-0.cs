	private static Image SplashScreenImage = GetSplashScreenImage();
	private Image ActualImage = null;
	private bool IsLoading = false;
	public Image ImageSrc
	{
		get
		{
			if (ActualImage != null)
				return ActualImage;
			if (!IsLoading)
			{
				IsLoading = true;
				// start loading image in background
				Task.Run(() =>
				{
					MemoryStream ms = new MemoryStream(GetImageAsByteArray());
					ActualImage = Image.FromStream(ms);
				}).ContinueWith(t => PropertyChanged("ImageSrc"), TaskScheduler.FromCurrentSynchronizationContext());
			}
			return SplashScreenImage;
        }
	}
