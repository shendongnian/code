    private static readonly DependencyProperty State1ColorProperty =
        DependencyProperty.Register(nameof(State1Color), typeof(Brush), typeof(WifiControl));
    public Brush State1Color
    {
        get { return (Brush)this.GetValue(State1ColorProperty); }
        set { this.SetValue(State1ColorProperty, value); }
    }
