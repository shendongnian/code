    const string dataTemplate = "<DataTemplate xmlns=\"http://schemas.microsoft.com/winfx/2006/xaml/presentation\"><TextBlock Text=\"{{Binding  {0}}}\" Foreground=\"{1}\" /></DataTemplate>";
    for (int i = 0; i<dt.Columns.Count; i++)
    {
        string colour = "Green"; ///change this one based on your colouring logic...
        DataTemplate template = System.Windows.Markup.XamlReader.Parse(string.Format(dataTemplate, dt.Columns[0].ColumnName, colour)) as DataTemplate;
        GridViewColumn gvc = new GridViewColumn() { CellTemplate = template };
        gvc.Header = "Column" + i;
        gvc.Width = 100;
        lvgvc.Columns.Add(gvc);
    }
    listView_data.Items.Clear();
    listView_data.ItemsSource = dt.DefaultView;
