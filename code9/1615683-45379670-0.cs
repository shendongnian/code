    class MyEventArgs : IDeferralSource
    {
      private IDeferralSource _deferralSource;
      public MyEventArgs(IDeferralSource deferralSource) { _deferralSource = deferralSource; }
      IDisposable GetDeferral() => _deferralSource.GetDeferral();
      ... // Other properties
    }
    public event MyEventHandler MyEvent;
    private async Task InvokeMyEventAsync()
    {
      var deferralManager = new DeferralManager();
      var args = new MyEventArgs(deferralManager.DeferralSource);
      MyEvent?.Invoke(this, args);
      await deferralManager.WaitForDeferralsAsync();
      MessageBox.Show(args.Result);
    }
