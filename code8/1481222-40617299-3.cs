    private void btn_execute_Click(object sender, RoutedEventArgs e)
    {
        for (int i = 0; i < 100; i++)
        {
            // Simulate doing some stuff...
            Thread.Sleep(100);
            output_log.Text += i + ", ";
            Dispatcher.Invoke(DispatcherPriority.Background, new Action(() => { }));
        }
    }
