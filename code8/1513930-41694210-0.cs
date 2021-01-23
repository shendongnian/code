    public static readonly DependencyProperty ScrollTargetProperty = DependencyProperty.RegisterAttached(
            "ScrollTarget", typeof(ScrollViewer), typeof(UserControl1), new PropertyMetadata(null));
        
    public static void SetScrollTarget(DependencyObject element, ScrollViewer value)
    {
       element.SetValue(ScrollTargetProperty, value);
    }
        
    public static ScrollViewer GetScrollTarget(DependencyObject element)
    {
       return (ScrollViewer)element.GetValue(ScrollTargetProperty);
    }
