        private async void GetFile()
        {
            var filePicker = new FileOpenPicker();
            filePicker.FileTypeFilter.Add(".jpg");
            filePicker.FileTypeFilter.Add(".png");
            filePicker.FileTypeFilter.Add(".gif");
            filePicker.FileTypeFilter.Add(".bmp");
            filePicker.ViewMode = PickerViewMode.Thumbnail;
            filePicker.SuggestedStartLocation = PickerLocationId.Desktop;
            filePicker.CommitButtonText = "Open";
            CurrentFile = await filePicker.PickSingleFileAsync(); //Bad code used CurrentFile set and NotifyPropertyChanged to start up the value converter code from OP
            //New, obvious better code            
            CurrentImage = await GetImageSource(CurrentFile);
            var statistics = new ImageStatistics();
            Logger.Log("Metadata start");
            var data = statistics.GetMetaData(CurrentFile);
            Logger.Log("Color Counts start");
            var colorCounts = statistics.GetColorCounts(CurrentFile);
            var filterer = new ColorFilterer();
            Logger.Log("Color Counts await start");
            var filteredColors = filterer.GetTopColors(await colorCounts, 10);
            Logger.Log("Color Counts await end");
            Logger.Log("Metadata await start");
            var metaData = await data;
            Logger.Log("Metadata await end");
            Make = metaData[SystemProperty.CameraManufacturer];
            Model = metaData[SystemProperty.CameraModel];
            ExposureTime = string.Format("1/{0}",1/Convert.ToDouble(metaData[SystemProperty.ExposureTime]));
            ISOSpeed = metaData[SystemProperty.ISOSpeed];
            FStop = string.Format("f/{0}", metaData[SystemProperty.FStop]);
            ExposureBias = metaData[SystemProperty.ExposureBias];
            TopColors = filteredColors.Select(pair => new ColorStatistics { Color = pair.Key, Count = pair.Value }).ToList();
        }
