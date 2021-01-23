    void Foo(IProgress<int> progress = null)
    {
      for (int i = 0; i < 1000; i++)
      {
        if (progress != null && i % 10 == 0) progress.Report(i / 10);
      }
    }
    // Caller
    var progress = new Progress<int>(report => ...);
    await Task.Run(() => Foo(progress));
