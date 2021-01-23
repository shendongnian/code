    private void UpdateCmd_Click(object sender, RoutedEventArgs e)
    {
      ThreadPool.QueueUserWorkItem(state =>
      {
        Thread.Sleep(10000);
        Dispatcher.Invoke(new Action(() =>
        {
          for (int i = 0; i < 100; i++)
          {
            ProgBar.Value++;
          }
        }));
      });
    }
