    public static readonly DependencyProperty ProjectedImageSourceProperty =
        DependencyProperty.Register(
            nameof(ProjectedImageSource),
            typeof(BitmapSource),
            typeof(MyViewer),
            new PropertyMetadata(
                (o, e) => ((MyViewer)o).imageModel3D.SetImage(e.NewValue as BitmapImage)));
 
