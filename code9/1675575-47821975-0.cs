    private async void Window_Loaded(object sender, RoutedEventArgs e)
    {
        await Task.Run(async () =>
        {
            foreach (var item in new string[] { "asd", "asdfasdf", "asd", "asdfasdf", "asd", "asdfasdf", "asd", "asdfasdf" })
            {
                //You have to invoke this on the dispatcher, because you are on a different thread right now.
                Application.Current.Dispatcher.Invoke(() => listbox.Items.Add(item));
                await Task.Delay(1000).ConfigureAwait(false);
            }
        }).ConfigureAwait(false);
    }
