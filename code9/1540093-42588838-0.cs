    new Thread(() =>
    {
            BitmapImage bitmapImage = ThreadProcedure();
            bitmapImage.Freeze(); //<--
            this.Dispatcher.Invoke(new Action(() => {
                pbStatus.Visibility = Visibility.Hidden;
                EditedImage.Source = bitmapImage;
            }));
    }).Start();
