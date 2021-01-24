    public class MyEventArgs: EventArgs, IDeferralSource
    {
      internal DeferralManager DeferralManager { get; } = new DeferralManager();
      public IDisposable GetDeferral() => DeferralManager.DeferralSource.GetDeferral();
    }
    public class MyContext : DbContext
    {
      public event EventHandler<MyEventArgs> SavingChanges;
      public override int SaveChanges(bool acceptAllChangesOnSuccess)
      {
        // You must decide to either throw or block here (see above).
        // Example code for blocking.
        var args = new MyEventArgs();
        SavingChanges?.Invoke(this, args);
        args.DeferralManager.WaitForDeferralsAsync().GetAwaiter().GetResult();
        return base.SaveChanges(acceptAllChangesOnSuccess);
      }
      public override async Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default(CancellationToken))
      {
        var args = new MyEventArgs();
        SavingChanges?.Invoke(this, args);
        await args.DeferralManager.WaitForDeferralsAsync();
        return await base.SaveChangesAsync(acceptAllChangesOnSuccess,  cancellationToken);
      }
    }
    // Usage (synchronous handler):
    myContext.SavingChanges += (sender, e) =>
    {
      Thread.Sleep(1000); // Synchronous code
    };
    // Usage (asynchronous handler):
    myContext.SavingChanges += async (sender, e) =>
    {
      using (e.GetDeferral())
      {
        await Task.Delay(1000); // Asynchronous code
      }
    };
