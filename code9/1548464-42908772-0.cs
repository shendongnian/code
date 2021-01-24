    private void Attach()
    {
        if (_control != null)
        {
            FrameworkElement fe = _control as FrameworkElement;
            if (fe != null)
            {
                if (fe.IsLoaded)
                {
                    WeakEventManager<UIElement, RoutedEventArgs>.AddHandler(_control, "MouseEnter", OnMouseEnter);
                    WeakEventManager<UIElement, RoutedEventArgs>.AddHandler(_control, "MouseLeave", OnMouseLeave);
                }
                else
                {
                    fe.Loaded += Fe_Loaded;
                }
            }
        }
    }
    private void Fe_Loaded(object sender, RoutedEventArgs e)
    {
        WeakEventManager<UIElement, RoutedEventArgs>.AddHandler(_control, "MouseEnter", OnMouseEnter);
        WeakEventManager<UIElement, RoutedEventArgs>.AddHandler(_control, "MouseLeave", OnMouseLeave);
    }
    private void Detach()
    {
        if (_control != null)
        {
            FrameworkElement fe = _control as FrameworkElement;
            if (fe != null)
                fe.Loaded += Fe_Loaded;
            WeakEventManager<UIElement, RoutedEventArgs>.RemoveHandler(_control, "MouseEnter", OnMouseEnter);
            WeakEventManager<UIElement, RoutedEventArgs>.RemoveHandler(_control, "MouseLeave", OnMouseLeave);
        }
    }
