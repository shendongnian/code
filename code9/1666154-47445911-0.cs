    private async void button_Click(object sender, RoutedEventArgs e)
    {
      if (Monitor.TryEnter(sender))
      {
        int fade1 = 1000;
        while (fade1 != -1)
        {
          await Task.Run( ()=> System.Threading.Thread.Sleep(30));
          fade1--;
        }
      }
    }
