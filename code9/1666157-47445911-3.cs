    private async void button_Click(object sender, EventArgs e)
    {
      if (Monitor.TryEnter(sender))
      {
        int fade1 = 1000;
        while (fade1 != -1)
        {
          await Task.Delay(30);
          fade1--;
        }
      }
    }
