    private void Show() {
	    if (Image != null)
		    WeakEventManager<System.Windows.Media.Imaging.BitmapSource, EventArgs>.RemoveHandler(Image, nameof(Image.DownloadCompleted), OnImageOnDownloadCompleted);
    	Image = new BitmapImage(new Uri("http://www.example.com/image.jpg"));
	    WeakEventManager<System.Windows.Media.Imaging.BitmapSource, EventArgs>.AddHandler(Image, nameof(Image.DownloadCompleted), OnImageOnDownloadCompleted);
    }
    private void OnImageOnDownloadCompleted(object sender, EventArgs args)
    {
        RadImage = new RadBitmap(Image);
    }
