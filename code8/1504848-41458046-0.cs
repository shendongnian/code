    public InkStrokeContainer Strokes
    {
        get { return (InkStrokeContainer)GetValue(StrokesProperty); }
        set { SetValue(StrokesProperty, value); }
    }
    
    public static readonly DependencyProperty StrokesProperty = DependencyProperty.Register("Strokes",
        typeof(InkStrokeContainer), typeof(InkCanvasControl),
        new PropertyMetadata(null, new PropertyChangedCallback(OnLabelChanged)));
    
    private static void OnLabelChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
    {
        (d as InkCanvasControl).InkPresenter.StrokeContainer = (InkStrokeContainer)e.NewValue;
    }
