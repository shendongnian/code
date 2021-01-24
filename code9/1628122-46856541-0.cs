    private void HamburgerMenu_Loaded(object sender, RoutedEventArgs e)
    {
        var selectedItem = this._buttonsListView?.SelectedItem ?? this._optionsListView?.SelectedItem;
        if (selectedItem != null)
        {
            this.SetCurrentValue(ContentProperty, selectedItem);
        }
    }
