      //for App folder path
                //var path = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetEntryAssembly().Location)+"\\Image\\pic.jpg";
    
                //for machine path
                var path = @"C:\Users\User1\Pictures\pic.jpg";
                Bitmap bmp = new Bitmap(path);
                MemoryStream ms = new MemoryStream();
                bmp.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                ms.Position = 0;
                BitmapImage bi = new BitmapImage();
                bi.BeginInit();
                bi.StreamSource = ms;
                bi.EndInit();
                imgPhoto.Source = bi;
