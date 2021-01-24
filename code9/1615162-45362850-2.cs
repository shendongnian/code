    private void Contact_Select(object send, MouseButtonEventArgs e)
    {
        var sender = (StackPanel)send;
        Keyboard.Focus(sender);
    }
    private void Got_Focus(object send, RoutedEventArgs e)
    {
        var sender = (StackPanel)send;
        AdornerLayer.GetAdornerLayer(sender).Add(new FocusAdorner(sender));
    }
    private void Lost_Focus(object send, RoutedEventArgs e)
    {
        var sender = (StackPanel)send;
        var layer = AdornerLayer.GetAdornerLayer(sender);
        foreach (var adorner in layer.GetAdorners(sender))
            layer.Remove(adorner);
    }
