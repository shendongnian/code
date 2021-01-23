    WrapperStream MasterStream{get;set;}
    
    private void ChangeImage()
    {
                SelectedImage = null;
                GC.Collect();
                var stream = new MemoryStream(ImageSource);
    
                using (MasterStream = new WrappingStream(stream))
                {
                    var bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.StreamSource = MasterStream;
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    bitmap.Freeze();
                    SelectedImage = bitmap;
                }
    
                GC.Collect();
                
     }
