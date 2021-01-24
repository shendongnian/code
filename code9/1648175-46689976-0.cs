    private async void OpenDialog_Click(object sender, RoutedEventArgs e)
    {
        TaskCompletionSource<bool> tcs = new TaskCompletionSource<bool>();
        var window = new DialogWindow();
        window.IsVisibleChanged += (ss, ee) =>
        {
            if (!window.IsVisible)
                tcs.SetResult(true);
        };
        window.Show();
        this.IsEnabled = false;
        await tcs.Task;
        MessageBox.Show("window hidden!");
    }
