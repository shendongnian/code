        PointerPoint Point1, Point2;
        SoftwareBitmap softwareBitmap;
        private async void OpenFile()
        {
            FileOpenPicker fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
            fileOpenPicker.FileTypeFilter.Add(".jpg");
            fileOpenPicker.ViewMode = PickerViewMode.Thumbnail;
            var inputFile = await fileOpenPicker.PickSingleFileAsync();
            if (inputFile == null)
            {
                // The user cancelled the picking operation
                return;
            }
            using (IRandomAccessStream stream = await inputFile.OpenAsync(FileAccessMode.Read))
            {
                // Create the decoder from the stream
                BitmapDecoder decoder = await BitmapDecoder.CreateAsync(stream);
                // Get the SoftwareBitmap representation of the file
                softwareBitmap = await decoder.GetSoftwareBitmapAsync();
            }
            if (softwareBitmap.BitmapPixelFormat != BitmapPixelFormat.Bgra8 ||
    softwareBitmap.BitmapAlphaMode == BitmapAlphaMode.Straight)
            {
                softwareBitmap = SoftwareBitmap.Convert(softwareBitmap, BitmapPixelFormat.Bgra8, BitmapAlphaMode.Premultiplied);
            }
            var source = new SoftwareBitmapSource();
            await source.SetBitmapAsync(softwareBitmap);
            image.Source = source;
        }
        private void Grid_PointerPressed(object sender, PointerRoutedEventArgs e)
        {
            Point1 = e.GetCurrentPoint(image);
        }
        private void Grid_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            Point2 = e.GetCurrentPoint(image);
        }
        private async void Grid_PointerReleased(object sender, PointerRoutedEventArgs e)
        {
            Point2 = e.GetCurrentPoint(image);
            rect.Visibility = Visibility.Visible;
            rect.Width = (int)Math.Abs(Point2.Position.X - Point1.Position.X);
            rect.Height = (int)Math.Abs(Point2.Position.Y - Point1.Position.Y);
            rect.SetValue(Canvas.LeftProperty, (Point1.Position.X < Point2.Position.X) ? Point1.Position.X : Point2.Position.X);
            rect.SetValue(Canvas.TopProperty, (Point1.Position.Y < Point2.Position.Y) ? Point1.Position.Y : Point2.Position.Y);
            await Task.Delay(100);
            RectangleGeometry geometry = new RectangleGeometry();
            geometry.Rect = new Rect(Point1.Position,Point2.Position);
            image.Clip = geometry;
        }
        private async void Save()
        {
            RenderTargetBitmap bitmap = new RenderTargetBitmap();
            await bitmap.RenderAsync(image);
            var pixelbuffer = await bitmap.GetPixelsAsync();
            var savefolder = ApplicationData.Current.LocalFolder;
            var savefile = await savefolder.CreateFileAsync("snapshot.png",CreationCollisionOption.GenerateUniqueName);
            using (var filestream = await savefile.OpenAsync(FileAccessMode.ReadWrite))
            {
                var encoder = await BitmapEncoder.CreateAsync(BitmapEncoder.PngEncoderId,filestream);
                encoder.SetPixelData(BitmapPixelFormat.Bgra8,BitmapAlphaMode.Ignore,(uint)bitmap.PixelWidth,(uint)bitmap.PixelHeight,DisplayInformation.GetForCurrentView().LogicalDpi,DisplayInformation.GetForCurrentView().LogicalDpi,pixelbuffer.ToArray());
                await encoder.FlushAsync();
            }
        }
