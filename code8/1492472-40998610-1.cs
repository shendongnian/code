    private void OnChecked(object sender, RoutedEventArgs e)
    {
        bool? isChecked = this.toggleButton.IsChecked;
        toggleButton.IsChecked = null;
        toggleButton.IsChecked = isChecked;
    }
