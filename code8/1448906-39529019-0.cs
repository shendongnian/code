    private static void OnPropertyChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        if (!disableProcessing)
        {
            // Only process the 5, don't process the 6
        }
    }
    bool disableProcessing = false;
    private void checkBox_Click(object sender, RoutedEventArgs e)
    {
        disableProcessing = true;
        MyProperty = 6;
        disableProcessing = false;
    }
