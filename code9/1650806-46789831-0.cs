    public static readonly DependencyProperty TileBackgroundIdProperty = DependencyProperty.Register("TileBackgroundId", typeof(int), typeof(MapTileBackgroundPreview),
        new PropertyMetadata(0, new PropertyChangedCallback(TileBackgroundIdChanged)));
    public int TileBackgroundId
    {
        get
        {
            return (int)GetValue(TileBackgroundIdProperty);
        }
        set
        {
            SetValue(TileBackgroundIdProperty, value);
        }
    }
    private static void TileBackgroundIdChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        MapTileBackgroundPreview ctrl = (MapTileBackgroundPreview)d;
        ctrl.TileBackground = TMapTileBackgroundTool.Get((int)e.NewValue);
    }
