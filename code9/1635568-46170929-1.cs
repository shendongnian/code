    private async void Search_Button_Click(object sender, RoutedEventArgs e)
    {
        LoadBar.Visibility = Visibility.Visible;
        ListViewData=await Task.Run(StartSearch(Search_TextBox.Text));
        LoadBar.Visibility = Visibility.Hidden;
    }
    private List<ListViewItemClass> SearchMDB()
    {
        var newData=new List<ListViewItemClass>();
        foreach (KeyValuePair<string, DataTable> _KVP in MDBContent)
        {
          for ()
          {
            .....
            newData.Add(_LC);
          }
        }
        return newData();
    }
