                var file = File.ReadAllBytes(_path);
                var bitmap = new BitmapImage();
                using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
                {
                    await stream.WriteAsync(file.AsBuffer());
                    stream.Seek(0);
                    await bitmap.SetSourceAsync(stream);
                }
