        public void ToggleLogView()
        {
            if (logView.Visibility == Visibility.Collapsed)
            {
                gridSplitterV.Visibility = Visibility.Visible;
                logView.Visibility = Visibility.Visible;
                logView.IsEnabled = true;
                menuItemShowLog.IsChecked = true;
                Grid.SetRowSpan(ListBoxGrid, 1);
            }
            else
            {
                logView.IsEnabled = false;
                gridSplitterV.Visibility = Visibility.Collapsed;
                logView.Visibility = Visibility.Collapsed;
                menuItemShowLog.IsChecked = false;
                Grid.SetRowSpan(ListBoxGrid, 3);
            }
        }
