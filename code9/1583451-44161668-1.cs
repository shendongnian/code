    private void btnProcessFIle_Click(object sender, EventArgs e)
    {
      var ui = SynchronizationContext.Current;
      Func<int> d = countCharacters;
      d.BeginInvoke(CountCharactersCallback, ui);
    }
    private void CountCharactersCallback(IAsyncResult ar) 
    {
      var d = (Func<int>) ((AsyncResult) ar).AsyncDelegate;
      var ui = (SynchronizationContext) ar.AsyncState;
      try
      {
        var count = d.EndInvoke(ar);
        ui.Post(CountCharactersComplete, count);
      }
      catch (Exception ex)
      {
        var edi = ExceptionDispatchInfo.Capture(ex);
        ui.Post(CountCharactersError, state);
      }
    }
    private void CountCharactersComplete(object state)
    {
      var count = (int) state;
      lblCount.Text = "No. of characters in file=" + count;
    }
    private void CountCharactersError(object state)
    {
      var edi = (ExceptionDispatchInfo)state;
      edi.Throw();
    }
