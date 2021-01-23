    private async void btn_execute_Click(object sender, RoutedEventArgs e)
    {
         for (int i = 0; i < 100; i++)
         {
             // Simulate doing some stuff...
             await Task.Delay(100);
             Dispatcher.Invoke(() => output_log.Text += i + ", ");
         }
    }
