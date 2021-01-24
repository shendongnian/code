        private async void checkProductMatches()
        {
            var selectedItem = string.Empty;
            //Check our results from DB.
            if (productResults.Count == 0)
            {
                //This means we didn't find any matches, show message dialog
            }
            if (productResults.Count == 1)
            {
                //We found one match, this is ideal. Continue processing.
                selectedItem = productResults.FirstOrDefault().Name;
            }
            if (productResults.Count > 1)
            {
                //Multiple matches, need to show ListView so they can select one.
                var myList = new ListView
                {
                    ItemTemplate = Create(),
                    ItemsSource =
                        productResults,
                        HorizontalAlignment = HorizontalAlignment.Stretch,
                        VerticalAlignment = VerticalAlignment.Stretch
                };
                var bounds = Window.Current.Bounds;
                var height = bounds.Height;
                var scroll = new ScrollViewer() { HorizontalAlignment = HorizontalAlignment.Stretch, VerticalAlignment = VerticalAlignment.Stretch, Height = height - 100 };
                var grid = new StackPanel();
                grid.Children.Add(myList);
                scroll.Content = grid;
                var dialog = new ContentDialog { Title = "Title", Content = scroll };
