    private async void btnMethod_Click(object sender, RoutedEventArgs e)
    {
        pgbStatus.Value = 0;
        await Task.Run((Action)Method);
        MessageBox.Show("Finished");
        pgbStatus.Value = 0;
    }
