      double m_scaleFactor;
      private async void btnrotatefile_Click(object sender, RoutedEventArgs e)
      {
          StorageFile file = await ApplicationData.Current.LocalFolder.GetFileAsync("test.bmp"); 
          using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.ReadWrite),
                                             memStream = new InMemoryRandomAccessStream())
          {
              BitmapDecoder decoder = await BitmapDecoder.CreateAsync(fileStream); 
              uint originalWidth = decoder.PixelWidth;
              uint originalHeight = decoder.PixelHeight;
              BitmapEncoder encoder = await BitmapEncoder.CreateForTranscodingAsync(memStream, decoder);
              if (m_scaleFactor != 1.0)
              {
                  encoder.BitmapTransform.ScaledWidth = (uint)(originalWidth * m_scaleFactor);
                  encoder.BitmapTransform.ScaledHeight = (uint)(originalHeight * m_scaleFactor);
                  encoder.BitmapTransform.InterpolationMode = BitmapInterpolationMode.Fant;
              }
             //Rotate 180
              encoder.BitmapTransform.Rotation = BitmapRotation.Clockwise180Degrees;
              await encoder.FlushAsync(); 
              memStream.Seek(0);
              fileStream.Seek(0);
              fileStream.Size = 0;
              await RandomAccessStream.CopyAsync(memStream, fileStream);
          }
      }
