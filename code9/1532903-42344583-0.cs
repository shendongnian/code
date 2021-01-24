    List<string> stringList = new List<string> { "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", "a", "b", "c", };
            DataTemplate dTemplate = new DataTemplate(() =>
            {
                StackLayout sl = new StackLayout
                {
                    Orientation = StackOrientation.Horizontal,
                    Padding = new Thickness(20, 10, 0, 10),
                    Spacing = 20
                };
                var temp = new Label { FontSize = 20 };
                temp.SetBinding(Label.TextProperty, ".");
                sl.Children.Add(temp);
                return new ViewCell { View = sl };
            });
            ListView myListView = new ListView
            {
                VerticalOptions = LayoutOptions.Fill,
                ItemsSource = stringList,
                ItemTemplate = dTemplate,
                BackgroundColor = Color.Red
            };
            this.Content = myListView;
