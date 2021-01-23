            myGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
            myGrid.ColumnDefinitions.Add(new ColumnDefinition());
            myGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
            Border b1 = new Border
            {
                Background = new SolidColorBrush(Colors.Blue),
                CornerRadius = new CornerRadius(100, 0, 0, 100)
            };
            Grid.SetColumn(b1, 0);
            Border b2 = new Border
            {
                Background = new SolidColorBrush(Colors.Blue),
            };
            Grid.SetColumn(b2, 1);
            Border b3 = new Border
            {
                Background = new SolidColorBrush(Colors.Blue),
                CornerRadius = new CornerRadius(0, 100, 100, 0),
            };
            Grid.SetColumn(b3, 2);
            myGrid.Children.Add(b1);
            myGrid.Children.Add(b2);
            myGrid.Children.Add(b3);
