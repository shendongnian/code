            BitmapImage biSource = new BitmapImage();
            using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
            {
                await stream.WriteAsync(bytes.AsBuffer());
                stream.Seek(0);
                await biSource.SetSourceAsync(stream);
            }
            image.Source = biSource;
 
