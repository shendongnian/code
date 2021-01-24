        private async void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < 40; i++)
            {
                StackPanel.Children.Add(new TextBlock
                {
                    Text = $"Item {i}",
                    FontSize = 40
                });
                await Task.Delay(500);
            }
        }
        private void StackPanel_OnSizeChanged(object sender, SizeChangedEventArgs e)
        {
            ScrollViewer.ChangeView(0, ScrollViewer.ScrollableHeight, 1);
        }
