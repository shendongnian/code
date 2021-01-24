    public override async Task<IEnumerable<ProcessResult>> ProcessAccount(DateTime? popDate = null)
    {
          foreach (item in accountNumbers)
          {
          
          trackedTasks.Add(new Func<Task<ProcessResult>>(async () =>
                {
                    await ss.WaitAsync().ConfigureAwait(false);
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
