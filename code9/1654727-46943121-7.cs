    private void ScanFilesInParallel()
    {
        FileList.Clear();
        Task.Run(() =>
        {
          var result = new List<string>();
          if (_jpgFilesChecked)
            result.AddRange(FileParser.ParseFiles(_osuDirectory, "*.jpg"));
          if (_pngFilesChecked)
            result.AddRange(FileParser.ParseFiles(_osuDirectory, "*.png"));
          if (_wavFilesChecked)
            result.AddRange(FileParser.ParseFiles(_osuDirectory, "*.wav"));
          if (_aviFilesChecked)
            result.AddRange(FileParser.ParseFiles(_osuDirectory, ".avi"));
          return result;
         })
         .ContinueWith<IEnumerable<string>>((task) => {
           task.Result.AddRange(files);
           BeginScanButton.Enabled = true;
         }, TaskScheduler.FromCurrentSynchronizationContext());
    }
