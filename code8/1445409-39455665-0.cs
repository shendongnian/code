    private void btnCapture_Click(object sender, RoutedEventArgs e)
    {     
      (int)captureElement.ActualWidth, (int)captureElement.ActualHeight, 96, 96, 
           PixelFormats.Default);
      bmp.Render(captureElement);
      BitmapEncoder encoder = new JpegBitmapEncoder();
      encoder.Frames.Add(BitmapFrame.Create(bmp));
      using (MemoryStream ms = new MemoryStream())
      {
           encoder.Save(ms);
 
      RenderTargetBitmap bmp = new RenderTargetBitmap(
                CaptureData = ms.ToArray();
      }
      DialogResult = true;
    }
