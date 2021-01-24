    var list = new ObservableCollection<string>();
    for (var i = 0; i < 10; i++)
    {
        list.Add(i.ToString() + "Template");
    }
    lstSrvMenu.ItemsSource = list;
