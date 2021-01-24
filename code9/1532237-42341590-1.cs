     private async void btnplay_Click(object sender, RoutedEventArgs e)
     {
         FileOpenPicker openPicker = new FileOpenPicker();
         openPicker.ViewMode = PickerViewMode.Thumbnail;
         openPicker.SuggestedStartLocation = PickerLocationId.PicturesLibrary;
         openPicker.FileTypeFilter.Add(".mp3");
         openPicker.FileTypeFilter.Add(".mp4");
         openPicker.FileTypeFilter.Add(".mkv");
         StorageFile file = await openPicker.PickSingleFileAsync();
         using (IRandomAccessStream readStream = await file.OpenAsync(FileAccessMode.Read))
         {
             try
             {
                 // Instantiate FFmpegInteropMSS using the opened local file stream
                 var FFmpegMSS = FFmpegInteropMSS.CreateFFmpegInteropMSSFromStream(readStream, false, false);
                 MediaStreamSource mss = FFmpegMSS.GetMediaStreamSource();
                 if (mss != null)
                 {
                     // Pass MediaStreamSource to Media Element
                     mediaElement.SetMediaStreamSource(mss);
                     // Close control panel after file open
                     //Splitter.IsPaneOpen = false;
                 }
                 else
                 {
                     System.Diagnostics.Debug.WriteLine("Cannot open media");
                 }
             }
             catch (Exception ex)
             {
                 System.Diagnostics.Debug.WriteLine((ex.Message));
             }
         }
     }
