      // Create the original MediaComposition
      var clip = await MediaClip.CreateFromFileAsync(pickedFile);
      composition = new MediaComposition();
      composition.Clips.Add(clip);
      // Add background audio
      var picker = new Windows.Storage.Pickers.FileOpenPicker();
      picker.SuggestedStartLocation = Windows.Storage.Pickers.PickerLocationId.MusicLibrary;
      picker.FileTypeFilter.Add(".mp3");
      picker.FileTypeFilter.Add(".wav");
      picker.FileTypeFilter.Add(".flac");
      var audioFile = await picker.PickSingleFileAsync();
      if (audioFile == null)
      {
          rootPage.NotifyUser("File picking cancelled", NotifyType.ErrorMessage);
          return;
      }
      var backgroundTrack = await BackgroundAudioTrack.CreateFromFileAsync(audioFile);
      composition.BackgroundAudioTracks.Add(backgroundTrack);
      // Render to MediaElement
      mediaElement.Position = TimeSpan.Zero;
      mediaStreamSource = composition.GeneratePreviewMediaStreamSource((int)mediaElement.ActualWidth, (int)mediaElement.ActualHeight);
      mediaElement.SetMediaStreamSource(mediaStreamSource);
