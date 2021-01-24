    for (int i = 0; i < X; i++)
    {
      var progress = Progress(); // returns a new IProgress<T>
      var task = RunIndefinitelyAsync(progress);
      TaskList.Add(task);
    }
    private async Task RunIndefinitelyAsync(IProgress<T> progress)
    {
      while (true)
      {
        try
        {
          await Task.Run(() => MyFunction(progress));
          // handle success
        }
        catch (Exception ex)
        {
          // handle exceptions
        }
        // update some labels/textboxes in the UI
      }
    }
