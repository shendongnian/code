    public static readonly DependencyProperty TabNameProperty =
        DependencyProperty.Register(nameof(TabName), typeof(string), typeof(GeneralTab));
    public string TabName
    {
        get { return (string)GetValue(TabNameProperty); }
        set { SetValue(TabNameProperty, value); }
    }
