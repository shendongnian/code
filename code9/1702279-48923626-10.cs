    public static readonly DependencyProperty FillProperty = Shape.FillProperty.AddOwner(
        typeof(CustomShape),
        new FrameworkPropertyMetadata((o, e) => ((CustomShape)o).FillPropertyChanged(e)));
    private void FillPropertyChanged(DependencyPropertyChangedEventArgs e)
    {
        rectangle.Fill = (Brush)e.NewValue;
    }
