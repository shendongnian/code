    var progress = new Progress<int>(value => { progressBar.Value = value; });
    await Task.Run(() => GenerateAsync(progress));
    void GenerateAsync(IProgress<int> progress)
    {
      ...
      progress?.Report(13);
      ...
    }
