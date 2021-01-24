    string directory = @".\Resources\imagini1";
               List<Image> imageList = new List<Image>();
               foreach (string fileImage in System.IO.Directory.GetFiles(directory, "*.png"))
               {
                   Image img = new Image();
                   System.Windows.Media.Imaging.BitmapImage source = new System.Windows.Media.Imaging.BitmapImage();
    
                   source.UriSource = new Uri(fileImage, UriKind.Relative);
                   img.Source = source;
                   img.Height = 20;
                   img.Width  = 20;
                   imageList.Add(img);
               }
              ListPicker_AdaugarePDI_Image.ItemsSource = imageList;
