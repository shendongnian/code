    private void OnLoaded(object sender, RoutedEventArgs e)
    {
        _isLoaded = true;
        DetermineOneRowMode();
    }
    private void DetermineOneRowMode()
    {
        if (_isLoaded)
        {
            var itemsWrapGridPanel = ItemsPanelRoot as ItemsWrapGrid;
            if (OneRowModeEnabled)
            {
                var b = new Binding()
                {
                    Source = this,
                    Path = new PropertyPath("ItemHeight")
                };
                if (itemsWrapGridPanel != null)
                {
                    _savedOrientation = itemsWrapGridPanel.Orientation;
                    itemsWrapGridPanel.Orientation = Orientation.Vertical;
                }
                SetBinding(MaxHeightProperty, b);
                ...
