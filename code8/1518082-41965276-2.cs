    public BitmapImage SavePhoto(string istrImagePath) 
    { 
      BitmapImage objImage = new BitmapImage(new Uri(istrImagePath, UriKind.RelativeOrAbsolute)); 
      objImage.DownloadCompleted += objImage_DownloadCompleted; 
      return objImage ; 
    } 
