    private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var listView = sender as ListView;
        var cmd = listView.DataContext?.GetType().GetProperty("PrintCurrentItemsCommand")?.
                      GetValue(listView.DataContext) as ICommand;
        if (cmd?.CanExecute(listView) ?? false)
        {
            cmd.Execute(listView);
        }
    }
