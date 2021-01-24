    public InkCanvas InkCanvas
    {
        get => (InkCanvas)GetValue(InkCanvasProperty);
        private set => SetValue(InkCanvasProperty, value);
    }
    public static readonly DependencyProperty InkCanvasProperty = DependencyProperty.Register(
        "InkCanvas", typeof(InkCanvas), typeof(InkCanvasWrapper), new PropertyMetadata(null));
