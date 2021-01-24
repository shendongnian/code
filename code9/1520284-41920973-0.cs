    for (int i = 0; i < dt.Columns.Count; i++)
    {
        GridViewColumn gvc = new GridViewColumn();
        gvc.Header = "Column" + i;
        gvc.Width = 100;
        gvc.DisplayMemberBinding = new Binding(dt.Columns[0].ColumnName);
        lvgvc.Columns.Add(gvc);
    }
    listView_data.Items.Clear();
    listView_data.ItemsSource = dt.DefaultView;
