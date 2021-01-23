    public static readonly DependencyProperty GISMapProperty = DependencyProperty.Register(
        nameof(GISMap), typeof(GISControl), typeof(GISPointSelecter),
        new PropertyMetadata(GISMapPropertyChanged));
    private static void GISMapPropertyChanged(
        DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
        var selector = (GISPointSelecter)o;
        if (e.OldValue != null)
        {
            var oldGisMap = (GISControl)e.OldValue;
            selector.LayoutRoot.Children.Remove(oldGisMap);
            oldGisMap.Click -= selector.Map_Click;
            oldGisMap.GISRequestedCloseSplash -= selector.GISMap_GISRequestedCloseSplash;
        }
        if (e.NewValue != null)
        {
            var newGisMap = (GISControl)e.NewValue;
            selector.LayoutRoot.Children.Insert(0, newGisMap);
            newGisMap.Click += selector.Map_Click;
            newGisMap.GISRequestedCloseSplash += selector.GISMap_GISRequestedCloseSplash;
        }
    }
    
