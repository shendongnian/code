    private void DoWork(IProgress<ProgressState> progress)
    {
      IsAnalyzing = true;
      progress.Report(new ProgressState(0, "Processing..."));
      int count = File.ReadLines(memoryFile).Count();
      StreamReader reader = new StreamReader(memoryFile);
      string line = "";
      int lineIndex = 0;
      while ((line = reader.ReadLine()) != null)
      {
        progress.Report(new ProgressState((int)(((double)lineIndex / count) * 100.0d));
        //Process record... (assume time consuming operation)
        HexRecord record = HexFileUtil.ParseLine(line);
        lineIndex++;
      }
      progress.Report(new ProgressState(100, "Done."));
      IsAnalyzing = false;
    }
    ...
    ObservableProgress.CreateAsync<ProgressState>(progress => Task.Run(() => DoWork(progress)))
        .Sample(TimeSpan.FromMilliseconds(250)) // Update UI every 250ms
        .ObserveOn(this) // Apply progress updates on UI thread
        .Subscribe(p =>
        {
          Progress = p.ProgressPercentage;
          Task = p.Task;
        });
