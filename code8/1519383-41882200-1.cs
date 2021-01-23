    public sealed partial class MainPage : Page
    {       
      private async void startBtn_Click(object sender, RoutedEventArgs e)
      {
        int asyncResult = 0;
        progressbar1.Value = 0;
        startBtn.IsEnabled = false;
        textBlock.Text += "button press log: " + startBtn.Content + " button is pressed" + Environment.NewLine;
        DateTime previousTime = DateTime.Now;
        var progress = new Progress<DateTime>(time =>
        {
          progressbar1.value = ...;
        });
        asyncResult = await Task.Run(() => Class1.DummyWork(previousTime, progress));
        textBlock.Text += "Task have been done" + Environment.NewLine;
        startBtn.IsEnabled = true;
      }
    }
