    public static readonly BindableProperty MaxProperty =
    BindableProperty.CreateAttached("Max", typeof(int), typeof(MaxValueEntry), 0);
    public int Max
    {
        get { return (int)GetValue(MaxProperty); }
        set { SetValue(MaxProperty, value); }
    }
