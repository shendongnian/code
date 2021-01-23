    public static void SetImage(Image img, string path, UriKind urikind)
    {            
    	if (!File.Exists(path))
    		return;
    	try
    	{
    		// load content into the image
    		BitmapImage b = new BitmapImage(new Uri(path, urikind));
    		img.Source = b;
    
    		// get actual pixel dimensions of image
    		double pixelWidth = (img.Source as BitmapSource).PixelWidth;
    		double pixelHeight = (img.Source as BitmapSource).PixelHeight;
    
    		// get dimensions of main window
    		MainWindow mw = Application.Current.Windows.OfType<MainWindow>().FirstOrDefault();
    		double windowWidth = mw.ActualWidth;
    		double windowHeight = mw.ActualHeight;
    
    		// set max dimensions on Image.ToolTip
    		ToolTip tt = (ToolTip)img.ToolTip;
    		tt.MaxHeight = windowHeight / 1.1;
    		tt.MaxWidth = windowWidth / 1.1;
    		img.ToolTip = tt;
    	}
    
    	catch (System.NotSupportedException ex)
    	{
    		img.Source = new BitmapImage();
    	}
    }
