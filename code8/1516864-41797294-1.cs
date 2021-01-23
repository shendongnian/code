	private async void Button_Click(object sender, RoutedEventArgs e)
	{
		WeakReference test = this.TestThing();
		GC.Collect();
		GC.WaitForPendingFinalizers();
		GC.Collect();
		GC.WaitForPendingFinalizers();
		Debug.WriteLine(test.IsAlive); // Returns false
	}
	private WeakReference TestThing()
	{
		byte[] imageData = File.ReadAllBytes(@"D:\docs\SpaceXLaunch_Shortt_3528.jpg");
		var image = new BitmapImage();
		using (var mem = new MemoryStream(imageData))
		{
			image.BeginInit();
			image.CreateOptions = BitmapCreateOptions.PreservePixelFormat;
			image.CacheOption = BitmapCacheOption.OnLoad;
			image.UriSource = null;
			image.StreamSource = mem;
			image.EndInit();
		}
		image.Freeze();
		return new WeakReference(image);
	}
