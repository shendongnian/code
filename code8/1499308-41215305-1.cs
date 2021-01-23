    public static readonly DependencyProperty GISMapProperty = DependencyProperty.Register(
        nameof(GISMap), typeof(GISControl), typeof(GISPointSelecter),
        new PropertyMetadata(GISMapPropertyChanged));
    private static void GISMapPropertyChanged(
        DependencyObject o, DependencyPropertyChangedEventArgs e)
    {
        ((GISPointSelecter)o).GISMapPropertyChanged(
            (GISControl)e.OldValue, (GISControl)e.NewValue);
    }
    private void GISMapPropertyChanged(GISControl oldGisMap, GISControl newGisMap)
    {
        if (oldGisMap != null)
        {
            LayoutRoot.Children.Remove(oldGisMap);
            oldGisMap.Click -= Map_Click;
            oldGisMap.GISRequestedCloseSplash -= GISMap_GISRequestedCloseSplash;
        }
        if (newGisMap != null)
        {
            LayoutRoot.Children.Insert(0, newGisMap);
            newGisMap.Click += Map_Click;
            newGisMap.GISRequestedCloseSplash += GISMap_GISRequestedCloseSplash;
        }
    }
    
