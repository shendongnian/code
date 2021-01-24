    void button_Click(object sender, RoutedEventArgs e)
    {
        button.Content = "123";
        //MessageBox.Show(button.ActualWidth.ToString()); // output: 0
        Dispatcher.Invoke(() => MessageBox.Show(button.ActualWidth.ToString()), DispatcherPriority.Render); // correct output
    }
