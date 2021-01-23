     void setImageSource(string file)
        {
            Dispatcher.Invoke(new Action(() =>
            {
                using (var stream = new FileStream(
                                        file, FileMode.Open, FileAccess.Read, FileShare.Read))
                {
                    image.Source = BitmapFrame.Create(
                        stream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
                }
            }));
        }
