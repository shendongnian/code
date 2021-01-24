    public void ToggleLogView()
    {
        if (logView.Visibility == Visibility.Collapsed)
        {
            gridSplitterV.Visibility = Visibility.Visible;
            logView.Visibility = Visibility.Visible;
            logView.Enabled = true;
            menuItemShowLog.IsChecked = true;
            //  This also works on my simplified test XAML, but you'll have to put 
            //  x:Name="ListBoxGrid" on the Grid that contains the ListBox.
            //Grid.SetRowSpan(ListBoxGrid, 1);
        }
        else
        {
            logView.Enabled = false;
            gridSplitterV.Visibility = Visibility.Collapsed;
            logView.Visibility = Visibility.Collapsed;
            menuItemShowLog.IsChecked = false;
            //  In the debugger, you'll see it already has this value
            //  Nevertheless, setting it forces a layout update. 
            //  It's a ridiculous way to do that, but I haven't found a better one
            PermanentRow.Height = new GridLength(1, GridUnitType.Star);
            //  This also works on my simplified test XAML, but you'll have to put 
            //  x:Name="ListBoxGrid" on the Grid that contains the ListBox.
            //Grid.SetRowSpan(ListBoxGrid, 3);
        }
    }
