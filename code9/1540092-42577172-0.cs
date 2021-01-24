             BitmapImage bitmapImage= ThreadProcedure();
             Dispatcher.BeginInvoke(DispatcherPriority.Input, new Action(() =>
             {
                 pbStatus.Visibility = Visibility.Hidden;
                 EditedImage.Source = bitmapImage;
             }));
