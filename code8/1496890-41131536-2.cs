    public static readonly DependencyProperty IDProperty = DependencyProperty.Register(
        "ID", typeof(int), typeof(DLBox),
        new FrameworkPropertyMetadata(
            0, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    public int ID
    {
        get { return (int)GetValue(IDProperty); }
        set { SetValue(IDProperty, value); }
    }
 
