    private ObservableCollecton<DBName> _source;
    private void ReadTryoutList_Loaded(object sender, RoutedEventArgs e)
    {
        ReadAllDBName dbName = new ReadAllDBName();
        DB_TryoutList = dbName.GetAllDBName();
        _source = new ObservableCollecton<DBName>(DB_TryoutList.OrderByDescending(i => i.ID).ToList());
        ListTryout.ItemsSource = _source;
        if (DB_TryoutList.Count == 0)
        {
            statuskosongStack.Visibility = Visibility.Visible;
            ListTryout.Visibility = Visibility.Collapsed;
        }
        else
        {
            statuskosongStack.Visibility = Visibility.Collapsed;
            ListTryout.Visibility = Visibility.Visible;
        }
    }
    private void deleteItemBtn_Click(object sender, RoutedEventArgs e)
    {
        var btn = sender as AppBarButton;
        var item = btn.DataContext as DBName;
        if (item != null)
        {
            _source.Remove(item);
            Db_Helper.DeleteQuiz(currentquiz.ID);
        }
    }
