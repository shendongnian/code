        private void OnMouseLeftButtonDown(object sender, MouseEventArgs e) {
            var textBlock = sender as TextBlock;
            if (textBlock == null) return;
            var relativePoint = VisualTreeHelper.GetOffset(textBlock);//textBlock.TransformToAncestor(Content).Transform(new Point(0, 0));
            //Almost invisible Background - If the user clicks it the menu is hidden
            var back = new Border{Background = new SolidColorBrush(Color.FromArgb(1,255,255,255))};
            back.MouseLeftButtonDown += (o, args) => {
                Content.Children.Remove(back.Tag as UIElement);
                Content.Children.Remove(back);
            };
            Content.Children.Add(back);
            //Build menu
            var menu = new Border{Background = new SolidColorBrush(Colors.White), Width = 200, Height = 500, BorderBrush = new SolidColorBrush(Colors.Gray), BorderThickness = new Thickness(1), HorizontalAlignment = HorizontalAlignment.Left, VerticalAlignment = VerticalAlignment.Top};
            back.Tag = menu;
            menu.RenderTransform = new TranslateTransform(relativePoint.X, relativePoint.Y + textBlock.ActualHeight + 5);
            //Do some more styling
            //Fill Menu here according to the tag of the TextBlock (switch(textBlock.Tag){...} or use a predefined view
            Content.Children.Add(menu);
            //Hide the Menu on click - TODO Implement logic to hide menu if a MenuItem was clicked...
            menu.MouseLeftButtonDown += (o, args) => {
                Content.Children.Remove(back.Tag as UIElement);
                Content.Children.Remove(back);
            };
        }
