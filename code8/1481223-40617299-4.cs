    private async void btn_execute_Click(object sender, RoutedEventArgs e)
    {
         for (int i = 0; i < 100; i++)
         {
             // Simulate doing some stuff...
             await Task.Delay(100);
             // Thanks to async/await the current context is captured and
             // switches automatically back to the Dispatcher thread after the await.
             output_log.Text += i + ", ";
             // If you were using Task.Run() instead then you would have to invoke it manually.
             // Dispatcher.Invoke(() => output_log.Text += i + ", ");
         }
    }
