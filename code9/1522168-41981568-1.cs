    public static readonly DependencyProperty LocalBranchIdProperty =
        DependencyProperty.Register(
            nameof(LocalBranchId), typeof(int?), typeof(BranchFilter),
            new PropertyMetadata(LocalBranchIdPropertyChanged));
    public int? LocalBranchId
    {
        get { return (int?)GetValue(LocalBranchIdProperty); }
        set { SetValue(LocalBranchIdProperty, value); }
    }
    private static void LocalBranchIdPropertyChanged(
        DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var control = (BranchFilter)obj;
        var id = (int?)e.NewValue;
        ...
    }
 
