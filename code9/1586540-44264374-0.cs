    private void DGrdDatosImportar_Drop(object sender, RoutedEventArgs e)
    {
        ...
        ScrollViewer sv = GetChildOfType<ScrollViewer>(DGrdDatosImportar);
        if (sv != null)
        {
            double horizontalOffset = sv.HorizontalOffset;
            //...
        }
    }
    private static T GetChildOfType<T>(DependencyObject depObj) where T : DependencyObject
    {
        if (depObj == null)
            return null;
        for (int i = 0; i < VisualTreeHelper.GetChildrenCount(depObj); i++)
        {
            var child = VisualTreeHelper.GetChild(depObj, i);
            var result = (child as T) ?? GetChildOfType<T>(child);
            if (result != null)
                return result;
        }
        return null;
    }
