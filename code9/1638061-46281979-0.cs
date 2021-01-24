    foreach (Sale s in sales)
    {
        StackPanel sp = new StackPanel { Orientation = Orientation.Horizontal };
        sp.Children.Add(new TextBlock { Text = s.Model + " " + s.Date.Value.ToShortDateString() });
        Button button = new Button { Content = "Удалить", Width = 55, Height = 20, FontSize = 13 };
        button.Click += (ss, ee) => DeleteSale(s);
        sp.Children.Add(button);
        databaseView.panelSale.Children.Add(new Expander
        {
            Name = "exp" + s.ID,
            Header = sp,
            Content = new SaleView { DataContext = s }
        });
    }
