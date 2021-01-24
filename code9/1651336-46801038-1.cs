    public class ImgToSrcConverter : IValueConverter
    {
    	private MyViewModel _dataContext;
    
        public object Convert(object value, Type targetType, object parameter,
                System.Globalization.CultureInfo culture)
        {
        	var dataContext = value as MyViewModel;
        	if (dataContext != null)
        	{
        		_dataContext = dataContext;
    
        		var image = dataContext.ImageSrc as Image;
    	        if (image != null)
    	        {
    	            MemoryStream ms = new MemoryStream();
    	            image.Save(ms, image.RawFormat);
    	            ms.Seek(0, SeekOrigin.Begin);
    	            BitmapImage bi = new BitmapImage();
    	            bi.BeginInit();
    	            bi.StreamSource = ms;
    	            bi.EndInit();
    
    	            bi.DownloadCompleted += new EventHandler(bi_DownloadCompleted);
    
    	            return bi;
    	        }
        	}
            return null;
        }
    
        public object ConvertBack(object value, Type targetType,
            object parameter, System.Globalization.CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    
        private void bi_DownloadCompleted(object sender, EventArgs e)
        {
         	_dataContext?.MyMethod();
        }
    }        
