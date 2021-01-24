    public static readonly DependencyProperty ProjectedImageSourceProperty =
        DependencyProperty.Register(
            nameof(ProjectedImageSource),
            typeof(BitmapSource),
            typeof(MyViewer),
            new PropertyMetadata(ProjectedImageSourceChanged));
    private static void ProjectedImageSourceChanged(
        DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var viewer = (MyViewer)obj;
            
        viewer.imageModel3D.SetImage(e.NewValue as BitmapImage); // may not be a BitmapImage
    }
