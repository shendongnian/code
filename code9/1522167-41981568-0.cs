    public static readonly DependencyProperty LocalBranchIdProperty =
        DependencyProperty.Register(
            nameof(LocalBranchId), typeof(int?), typeof(BranchFilter));
    public int? LocalBranchId
    {
        get { return (int?)GetValue(LocalBranchIdProperty); }
        set { SetValue(LocalBranchIdProperty, value); }
    }
