    private async void Search_Button_Click(object sender, RoutedEventArgs e)
    {
        LoadBar.Visibility = Visibility.Visible;
        await Task.Run(StartSearch(Search_TextBox.Text));
        LoadBar.Visibility = Visibility.Hidden;
    }
    private void SearchMDB()
    {
        ListViewData.Clear();
        foreach (KeyValuePair<string, DataTable> _KVP in MDBContent)
        {
            .....
        }
    }
