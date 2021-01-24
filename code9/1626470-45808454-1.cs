        this.Dispatcher.Invoke(
            new Action<Bitmap>(
                (bitmap) =>
                {
                    pboLive.Source = ImageSourceForBitmap(bitmap);
                }
            ),
            (Bitmap)eventArgs.Frame.Clone()
            );
