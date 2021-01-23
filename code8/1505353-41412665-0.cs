    AssociatedObject.Loaded += AssociatedObjectOnLoaded;
    private void AssociatedObjectOnLoaded(object sender, RoutedEventArgs routedEventArgs)
    {
        _thumb = ((Track)AssociatedObject.Template.FindName("PART_Track", AssociatedObject))?.Thumb;
    }
