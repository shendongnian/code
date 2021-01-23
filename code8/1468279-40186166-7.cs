    private void UpdateCmd_Click(object sender, RoutedEventArgs e)
    {
      ThreadPool.QueueUserWorkItem(state =>
      {
        Thread.Sleep(10000);
        for (int i = 0; i < 100; i++)
        {
          Dispatcher.Invoke(new Action(() =>
          {
            ProgBar.Value++;
          }));
          Thread.Sleep(50);
        }
      });
    }
