    // Option 1
    Task Foo (Action<int> onProgressPercentChanged)
    {
      return Task.Run (() =>
      {
        for (int i = 0; i < 1000; i++)
        {
          if (i % 10 == 0) onProgressPercentChanged (i / 10);
        }
      });
    }
    // Option 2
    async Task Foo (Action<int> onProgressPercentChanged)
    {
      await Task.Run (() =>
      {
        for (int i = 0; i < 1000; i++)
        {
          if (i % 10 == 0) onProgressPercentChanged (i / 10);
        }
      });
    }
