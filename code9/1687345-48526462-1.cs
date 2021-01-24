    public override async Task<IEnumerable<ProcessResult>> ProcessAccount(DateTime? popDate = null)
    {
          foreach (item in accountNumbers)
          {
          await ss.WaitAsync().ConfigureAwait(false);
          trackedTasks.Add(new Func<Task<ProcessResult>>(async () =>
                {
                    try
                    {
                        return await ProcessAccount(item.AccountCode, popDate ?? DateTime.Today).ConfigureAwait(false);
                    }
                    catch (Exception e)
                    {
                        //log, etc.
                    }
                    finally
                    {
                        ss.Release();
                    }
                })());
          }
    }
