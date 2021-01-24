    protected override async void MyNewMethod()
    {
      try
      {
        await Task.Run(() => DoStuff1());
        DoSuccessStuff2();
      }
      catch (Exception ex)
      {
        DoErrorStuff2();
      }
    }
