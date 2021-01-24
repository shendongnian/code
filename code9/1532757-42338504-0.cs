    List<string> stringList = new List<string> { "a", "b", "c" };
    ListView myListView = new ListView
    {
        ItemsSource = stringList,
        ItemTemplate = new DataTemplate(() =>
        {
            StackLayout sl = new StackLayout
            {
                 VerticalOptions = LayoutOptions.FillAndExpand,
                 Orientation = StackOrientation.Horizontal,
            };
            var temp = new Label
            {
                FontSize = 14,
            };
            temp.SetBinding(Label.TextProperty, ".");
            sl.Children.Add(temp);
            return new ViewCell { View = sl };
       })
    };
