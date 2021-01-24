    public static DependencyProperty MiniMapProperty =
        DependencyProperty.Register("MiniMap", 
        typeof(bool), 
        typeof(myMap), 
        new PropertyMetadata(new PropertyChangedCallback(OnMiniMapPropertyChanged)));
    private static void OnMiniMapPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
            {
                var control = sender as myMap;
                if (control != null && (bool)e.NewValue == true)
                    control.Title.Text = "";
            }
