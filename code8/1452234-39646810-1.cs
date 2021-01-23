    private void UpdateProgress(string s)
    {
      MainWindow.AppWindow.Dispatcher.Invoke(() =>
      {
        this.Updates.Add(s);
        //});
      });
    }
