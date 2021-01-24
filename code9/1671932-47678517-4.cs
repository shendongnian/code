    public static readonly DependencyProperty CUProperty =
        DependencyProperty.Register(
            nameof(CU),
            typeof(CreditUnion),
            typeof(CULabelConfigControl),
            new PropertyMetadata(CUPropertyChanged));
    private static void CUPropertyChanged(
        DependencyObject obj, DependencyPropertyChangedEventArgs e)
    {
        var control = (CULabelConfigControl)obj;
        // react on value change here
    }
