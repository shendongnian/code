    private static CancellationTokenSource _tokenSource;
    private static Progress<string> _progress = new Progress<string>((msg) => Console.WriteLine(msg));
    private static IProgress<string> _progressReporter = _progress as IProgress<string>;
    static void Main(string[] args)
    {
      Task.Run(async () => await Run()).GetAwaiter().GetResult();
    }
    private static async Task Run()
    {
      try
      {
        Console.CancelKeyPress += Console_CancelKeyPress;
        using (_tokenSource = new CancellationTokenSource())
        {
          _progressReporter.Report("Running 3 async tasks... press [Ctrl+C] to cancel.\r\n");
          await Task.WhenAll
          (
              DoWorkAsync(1, 6, _tokenSource.Token, _progress),
              DoWorkAsync(2, 3, _tokenSource.Token, _progress),
              DoWorkAsync(3, 4, _tokenSource.Token, _progress)
          );
          _progressReporter.Report($"\r\nRun complete: All tasks finished successfully (without user cancelling)");
        }
      }
      catch (OperationCanceledException)
      {
        _progressReporter.Report($"\r\nRun complete: User cancelled one or more ongoing tasks");
      }
      finally
      {
        Console.ReadLine(); // pause
      }
    }
    private static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
    {
      _progressReporter.Report("\r\nCancelling tasks...\r\n");
      _tokenSource.Cancel();
      e.Cancel = true;
    }
    private static async Task DoWorkAsync(int taskNumber, int durationInSeconds, CancellationToken ct, IProgress<string> progress)
    {
      await Task.Run(() => 
      {
        if (ct.IsCancellationRequested)
        {
          progress.Report($"Task {taskNumber} cancelled before it started");
          return;
        }
        else
          progress.Report($"Started task {taskNumber} (duration: {durationInSeconds} sec. steps)");
        for (int i = 0; i < durationInSeconds; i++)
        {
          progress.Report($"Task {taskNumber} is working (on step {i + 1}/{durationInSeconds})");
          Thread.Sleep(1000); // simulate work in 1 sec steps
          if (ct.IsCancellationRequested)
          {
            progress.Report($"Task {taskNumber} cancelled after it started (on step {i + 1}/{durationInSeconds})");
            ct.ThrowIfCancellationRequested();
          }
        }
        progress.Report($"Finished task {taskNumber}");
      });
    }
