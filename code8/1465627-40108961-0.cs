    public static Task ToRepeatingWork(this Action work, int delayInMilliseconds)
    {
      Func<Task> action = async () =>
      {                
        while (true)
        {
          try
          {
            work();
          }
          catch (MyException ex)
          {
            // Do Nothing
          }
          await TaskEx.Delay(new TimeSpan(0, 0, 0, 0, delayInMilliseconds));
        }
      };
      return Task.Run(() => action());
    }
    [TestMethod, TestCategory("Unit")]
    public async Task Should_do_repeating_work_and_rethrow_exceptions()
    {
      Action work = () =>
      {
        throw new Exception("Some other exception.");
      };
      var task = work.ToRepeatingWork(1);
      await task;
    }
