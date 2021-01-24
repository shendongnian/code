    StackLayout Scroller = new StackLayout { 
                Padding = new Thickness(10, 0, 10, 0),
                Orientation = StackOrientation.Horizontal,
                Spacing = 375 / 100 + 10,
            };
            ScrollView Scroll = new ScrollView { 
                Orientation = ScrollOrientation.Horizontal,
            };
            Scroll.Content = Scroller; 
