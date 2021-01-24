    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var rd = myGrid.RowDefinitions.ToList();
        var cd = myGrid.ColumnDefinitions.ToList();
        myGrid.RowDefinitions.Clear();
        myGrid.ColumnDefinitions.Clear();
        foreach (var item in cd)
        {
            myGrid.RowDefinitions.Add(new RowDefinition() { Height = item.Width });
        }
        foreach (var item in rd)
        {
            myGrid.ColumnDefinitions.Add(new ColumnDefinition() { Width = item.Height });
        }
        foreach (UIElement child in myGrid.Children)
        {
            var r = child.GetValue(Grid.RowProperty);
            child.SetValue(Grid.RowProperty, child.GetValue(Grid.ColumnProperty));
            child.SetValue(Grid.ColumnProperty, r);
        }
    }
