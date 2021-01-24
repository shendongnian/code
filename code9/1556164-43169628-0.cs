    public class MyContext : DbContext
    {
      public event AsyncEventHandler<EventArgs> SavingChangesAsync;
      public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
      {
        var delegates = SavingChangesAsync;
        if (delegates != null)
        {
          var tasks = delegates
            .GetInvocationList()
            .Select(d => ((AsyncEventHandler<EventArgs>)d)(this, EventArgs.Empty))
            .ToList();
          await Task.WhenAll(tasks);
        }
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess, cancellationToken);
      }
    }
