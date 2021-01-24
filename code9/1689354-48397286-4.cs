    private void BtnPrint_Click(object sender, RoutedEventArgs e)
    {
       try
       {
           var size = GetElementPixelSize(gridCard);
           double w = size.Width;
           double h = size.Height;
           double dpiScale = 300.0 / 99.9;
           double dpiX = 300.0;
           double dpiY = 300.0;
           RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(Convert.ToInt32((w) * dpiScale), Convert.ToInt32((h) * dpiScale), dpiX, dpiY, PixelFormats.Pbgra32);
    
           renderTargetBitmap.Render(gridCard);
    
           PngBitmapEncoder pngImage = new PngBitmapEncoder();
           pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));
           var biRotated = new BitmapImage();
           using (Stream fileStream = new MemoryStream()) 
           {
                pngImage.Save(fileStream);
                fileStream.Seek(0, SeekOrigin.Begin);
    
                biRotated.BeginInit();
                biRotated.CacheOption = BitmapCacheOption.OnLoad;
                biRotated.StreamSource = fileStream;
                // biRotated.Rotation = Rotation.Rotate90; // if you need it
                biRotated.EndInit();
           }
    
           var vis = new DrawingVisual();
           var dc = vis.RenderOpen();
           dc.DrawImage(biRotated, new Rect { Width = biRotated.Width, Height = biRotated.Height });
           dc.Close();
    
           var pdialog = new System.Windows.Controls.PrintDialog();
           if (pdialog.ShowDialog() == true)
           {
               pdialog.PrintVisual(vis, "Proxy-card");
              }
       }
       catch (Exception ex)
       {
           System.Windows.MessageBox.Show("Print error " + ex.Message);
       }
    }
    
    // https://stackoverflow.com/questions/3286175/how-do-i-convert-a-wpf-size-to-physical-pixels
    public Size GetElementPixelSize(UIElement element)
    {
        Matrix transformToDevice;
        var source = PresentationSource.FromVisual(element);
        if (source != null)
          transformToDevice = source.CompositionTarget.TransformToDevice;
        else
        {
          // IntPtr hWnd = source.Handle;
          using (var source1 = new HwndSource(new HwndSourceParameters()))
          {
              transformToDevice = source1.CompositionTarget.TransformToDevice;
          }
        }
        if (element.DesiredSize == new Size())
                    element.Measure(new Size(double.PositiveInfinity, double.PositiveInfinity));
    
         return (Size)transformToDevice.Transform((Vector)element.DesiredSize);
    }
    
    
        
